using System.Collections.Generic;

internal sealed class UnitManager
{
    public EventHandler<Unit> OnUnitCreated = new();
    public EventHandler<Unit, Unit> OnUnitAttacking = new();
    public EventHandler<Unit> OnUnitBuffPressedEvent = new();

    public List<Unit> units = new List<Unit>();

    public void OnUnitStartMove(Unit currentUnit)
    {
        foreach (Unit unit in units)
        {
            if (unit == currentUnit)
            {
                unit.EndbleUI();
            }
            else
            {
                unit.DisableUI();
            }
        }
    }

    public void OnUnitAttacked(Unit unit)
    {
        unit.UpdateUIData();
    }

    public void OnUnitBuffPressed(Unit unit)
    {
        OnUnitBuffPressedEvent.Handle(unit);
    }

    public void OnUnitChooseBuff(Unit unit, IBuff buff)
    {
        unit.AddBuff(buff);
        Unit enemy = GetAnotherUnit(unit);

        unit.unitConfigBuff = new UnitConfigBuff(unit.unitConfig);
        enemy.unitConfigBuff = new UnitConfigBuff(enemy.unitConfig);

        ApplyBuffs(unit, enemy);
        ApplyBuffs(enemy, unit);

        unit.UpdateUIData();
        enemy.UpdateUIData();
    }

    private void ApplyBuffs(Unit self, Unit enemy)
    {
        foreach (IBuff buff in self._buffs)
        {
            buff.Apply(self.unitConfigBuff, enemy.unitConfigBuff);
        }
    }

    public void OnStartGame()
    {
        CreateUnits();
    }

    private void CreateUnits()
    {
        CreateUnit(ResourcePathes.FIRST_UNIT_SETTINGS, ResourcePathes.FIRST_UNIT_POS, ResourcePathes.LEFT_UNIT_UI_POS);
        CreateUnit(ResourcePathes.SECOND_UNIT_SETTINGS, ResourcePathes.SECOND_UNIT_POS, ResourcePathes.RIGHT_UNIT_UI_POS);
    }

    private Unit GetAnotherUnit(Unit currentUnit)
    {
        foreach (Unit unit in units)
        {
            if (unit != currentUnit) return unit;
        }
        return currentUnit;
    }

    private void OnUnitAttack(Unit currentuUnit)
    {
        Unit unitFrom = currentuUnit;
        Unit unitTo = GetAnotherUnit(currentuUnit);

        OnUnitAttacking.Handle(unitFrom, unitTo);

        unitFrom.DecreaseBuffTime();

        Unit enemy = GetAnotherUnit(currentuUnit);

        unitFrom.unitConfigBuff = new UnitConfigBuff(unitFrom.unitConfig);
        unitTo.unitConfigBuff = new UnitConfigBuff(unitTo.unitConfig);

        ApplyBuffs(currentuUnit, enemy);
        ApplyBuffs(enemy, currentuUnit);

        currentuUnit.UpdateUIData();
        enemy.UpdateUIData();
    }

    private void CreateUnit(string configPath, string configPosPath, string uiParentPosPath)
    {
        Unit unit = new Unit(configPath, configPosPath, uiParentPosPath);
        units.Add(unit);
        unit.OnUnitAttack.AddHandler(OnUnitAttack);
        unit.OnUnitBuffBressed.AddHandler(OnUnitBuffPressed);

        OnUnitCreated.Handle(unit);
    }
}

