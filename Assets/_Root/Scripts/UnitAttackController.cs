using UnityEngine;

internal sealed class UnitAttackController
{
    public EventHandler<Unit> OnUnitAttacked = new();
    public EventHandler OnAttacked = new();

    public void OnUnitAttacking(Unit unitFrom, Unit unitTo)
    {
        Debug.Log(unitFrom.unitConfigBuff.attackForce);
        unitTo.unitConfig.health = unitTo.unitConfig.health - unitFrom.unitConfigBuff.attackForce;
        OnUnitAttacked.Handle(unitTo);
        OnAttacked.Handle();
    }

}
