using UnityEngine;

internal sealed class DoubleDamageBuff : IBuff
{
    private int _roundLeft;
    public int RoundLeft => _roundLeft;
    public int ID => 0;
    
    public DoubleDamageBuff(int roundLeft)
    {
        _roundLeft = roundLeft;
    }

    public void Apply(UnitConfigBuff selfUnit, UnitConfigBuff enemyUnit)
    {
        selfUnit.attackForce *= 2;
    }

    public void SetRoundLeft(int value)
    {
        _roundLeft = value;
    }
    public IBuff Clone()
    {
        return new DoubleDamageBuff(_roundLeft);
    }
}


