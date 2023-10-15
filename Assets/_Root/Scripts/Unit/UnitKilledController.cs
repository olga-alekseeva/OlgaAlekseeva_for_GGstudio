using UnityEngine;

internal sealed class UnitKilledController
{
    public void OnUnitDied(Unit unit)
    {
        if(unit.unitConfigBuff.health == 0)
        {
            unit.unitConfigBuff.unitColor = Color.grey;
        }
    }
}

