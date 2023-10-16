internal interface IBuff
{
    public int RoundLeft { get; }
    public int ID { get; }

    public void SetRoundLeft(int value);
    public void Apply(UnitConfigBuff selfUnit, UnitConfigBuff enemyUnit);
    public IBuff Clone();

}
