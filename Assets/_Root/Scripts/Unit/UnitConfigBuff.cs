using UnityEngine;

internal sealed class UnitConfigBuff
{
    public string unitName;
    public float attackForce;
    public float health;
    public float armor;
    public float vampirism;
    public Color unitColor;

    public UnitConfigBuff(UnitConfig unitConfig)
    {
        unitName = unitConfig.unitName;
        attackForce = unitConfig.attackForce;
        health = unitConfig.health;
        armor = unitConfig.armor;
        vampirism = unitConfig.vampirism;
        unitColor = unitConfig.unitColor;
    }
}
