internal sealed class ArmorSelfBuff : IBuff
{
    private int _roundLeft;
    public int RoundLeft => _roundLeft;
    public int ID => 1;
   
    public ArmorSelfBuff(int roundLeft)
    {
        _roundLeft = roundLeft;
    }

    public void Apply(UnitConfigBuff selfUnit, UnitConfigBuff enemyUnit)
    {
        selfUnit.armor += 50;
    }

    public void SetRoundLeft(int value)
    {
        _roundLeft = value;
    }
    public IBuff Clone()
    {
        return new ArmorSelfBuff(_roundLeft);
    }

}
