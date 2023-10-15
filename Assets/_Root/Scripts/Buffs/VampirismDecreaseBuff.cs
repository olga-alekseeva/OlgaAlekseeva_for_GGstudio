internal sealed class VampirismDecreaseBuff : IBuff
{
    private int _roundLeft;
    public int RoundLeft => _roundLeft;
    public int ID => 0;

    public VampirismDecreaseBuff(int roundLeft)
    {
        _roundLeft = roundLeft;
    }

    public void Apply(UnitConfigBuff selfUnit, UnitConfigBuff enemyUnit)
    {
        enemyUnit.vampirism -= 25;
        if(enemyUnit.vampirism == 0)
        {
            enemyUnit.vampirism = 0;
        }
    }

    public void SetRoundLeft(int value)
    {
        _roundLeft = value;
    }
}
