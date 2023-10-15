using UnityEngine;

internal sealed class UnitConfigBuff
{
    public int countNumber;
    public string unitName;
    public int attackForce;
    public float health;
    public float armor;
    public float vampirism;
    public Color unitColor;
    public bool isEnabled = true;

    public UnitConfigBuff(UnitConfig unitConfig)
    {
        countNumber = unitConfig.countNumber;
        unitName = unitConfig.unitName;
        attackForce = unitConfig.attackForce;
        health = unitConfig.health;
        armor = unitConfig.armor;
        unitColor = unitConfig.unitColor;
        isEnabled = unitConfig.isEnabled;
    }
}
