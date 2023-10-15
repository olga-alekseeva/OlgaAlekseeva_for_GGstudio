﻿using Extension;
using System.Collections.Generic;

internal class BuffManager
{
    public EventHandler<Unit, IBuff> OnUnitChooseBuff = new();

    private List<IBuff> _availableBuffs = new();

    public BuffManager()
    {
        CreateAvaibleBuffs();
    }

    private void CreateAvaibleBuffs()
    {
        _availableBuffs.Add(new DoubleDamageBuff(0));
    }

    public void ButtonBuffPressed(Unit unit)
    {
        IBuff newRandomBuff = GetRandom(_availableBuffs, unit._buffs);
        if (newRandomBuff == null) return;
        OnUnitChooseBuff.Handle(unit, newRandomBuff);
    }

    public bool IsBuffInList(List<IBuff> buffs, IBuff currentBuff)
    {
        foreach (IBuff buff in buffs)
        {
            if (buff.ID == currentBuff.ID) return true;
        }
        return false;
    }

    public IBuff GetRandom(List<IBuff> available, List<IBuff> unitbuff)
    {
        if (unitbuff.Count >= 2) return null;
        IBuff newBuff = available.GetRandom();
        if (IsBuffInList(unitbuff, newBuff)) return null;
        return newBuff;
    }
}
