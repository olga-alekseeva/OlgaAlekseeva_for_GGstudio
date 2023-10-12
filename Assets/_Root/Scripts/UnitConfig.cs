using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(UnitConfig), menuName = "ScriptableObject/" + nameof(UnitConfig))]
public class UnitConfig : ScriptableObject
{
    public int countNumber;
    public float health;
    public float armor;
    public float vampirism;

}
