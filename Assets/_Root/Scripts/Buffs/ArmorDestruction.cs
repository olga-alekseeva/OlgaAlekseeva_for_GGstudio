internal sealed class ArmorDestruction: IBuff
{
    private int _roundLeft;
    public int RoundLeft => _roundLeft;
    public int ID => 2;

    public ArmorDestruction(int roundLeft)
    {
        _roundLeft = roundLeft;
    }

    public void Apply(UnitConfigBuff selfUnit, UnitConfigBuff enemyUnit)
    {
        if (enemyUnit.armor == 0) return;
            enemyUnit.armor -= 10;
    }

    public void SetRoundLeft(int value)
    {
        _roundLeft = value;
    }
    public IBuff Clone()
    {
        return new ArmorDestruction(_roundLeft);
    }

}
