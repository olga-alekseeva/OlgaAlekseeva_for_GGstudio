using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(UnitPositionConfig), menuName = "ScriptableObject/" + nameof(UnitPositionConfig))]

public class UnitPositionConfig : ScriptableObject
{
    public Vector3 position;
}
