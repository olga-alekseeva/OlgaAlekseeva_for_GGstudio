internal sealed class VampirismDecreaseBuff : IBuff
{
    private int _roundLeft;
    public int RoundLeft => _roundLeft;
    public int ID => 4;

    public VampirismDecreaseBuff(int roundLeft)
    {
        _roundLeft = roundLeft;
    }

    public void Apply(UnitConfigBuff selfUnit, UnitConfigBuff enemyUnit)
    {
        if (enemyUnit.vampirism == 0) return;
        enemyUnit.vampirism -= 25;
    }

    public void SetRoundLeft(int value)
    {
        _roundLeft = value;
    }
    public IBuff Clone()
    {
        return new VampirismDecreaseBuff(_roundLeft);
    }

}
