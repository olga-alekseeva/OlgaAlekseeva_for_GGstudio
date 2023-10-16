internal sealed class VampirismSelfBuff : IBuff
{
    private int _roundLeft;
    public int RoundLeft => _roundLeft;
    public int ID => 3;

    public VampirismSelfBuff(int roundLeft)
    {
        _roundLeft = roundLeft;
    }

    public void Apply(UnitConfigBuff selfUnit, UnitConfigBuff enemyUnit)
    {
        selfUnit.vampirism += 50;
        if (selfUnit.armor == 0) return;
        selfUnit.armor -= 25;
    }
    public void SetRoundLeft(int value)
    {
        _roundLeft = value;
    }
    public IBuff Clone()
    {
        return new VampirismSelfBuff(_roundLeft);
    }

}
