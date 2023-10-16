internal sealed class UnitAttackController
{
    public EventHandler<Unit> OnUnitAttacked = new();
    public EventHandler OnAttacked = new();
    public EventHandler<Unit> OnUnitDied = new();

    public void OnUnitAttacking(Unit unitFrom, Unit unitTo)
    {
        unitTo.unitConfig.health = unitTo.unitConfig.health - (100 - unitTo.unitConfig.armor) / 100 * unitFrom.unitConfigBuff.attackForce;
        if (unitTo.unitConfig.health <= 0)
        {
            unitTo.unitConfig.health = 0;
            OnUnitDied.Handle(unitTo);
        }
        OnUnitAttacked.Handle(unitTo);
        OnAttacked.Handle();
    }

}

