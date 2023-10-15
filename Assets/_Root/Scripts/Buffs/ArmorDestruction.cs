internal sealed class ArmorDestruction: IBuff
{
    private int _roundLeft = 3;
    public int RoundLeft => _roundLeft;
    public int ID => 2;

    public ArmorDestruction(int roundLeft)
    {
        _roundLeft = roundLeft;
    }

    public void Apply(UnitConfigBuff selfUnit, UnitConfigBuff enemyUnit)
    {
        enemyUnit.armor -= 10;
        if (enemyUnit.armor <= 0)
        {
            enemyUnit.armor = 0;
        }
    }

    public void SetRoundLeft(int value)
    {
        _roundLeft = value;
    }
}
