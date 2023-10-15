internal sealed class VampirismSelfBuff : IBuff
{
    private int _roundLeft;
    public int RoundLeft => _roundLeft;
    public int ID => 0;

    public VampirismSelfBuff(int roundLeft)
    {
        _roundLeft = roundLeft;
    }

    public void Apply(UnitConfigBuff selfUnit, UnitConfigBuff enemyUnit)
    {
        selfUnit.armor -= 25;
        if (selfUnit.armor == 0)
        {
            selfUnit.armor = 0;
        }
        selfUnit.vampirism += 50;
    }
    public void SetRoundLeft(int value)
    {
        _roundLeft = value;
    }
}
