using UnityEngine;

internal sealed class UnitViewFactory
{
    private GameObject _prefab;
    public UnitViewFactory()
    {
        _prefab = Resources.Load<GameObject>("Prefabs/Units/Unit");
    }
    public GameObject InstantiateUnits(UnitPositionConfig unitPositionConfig)
    {
        GameObject go = GameObject.Instantiate(_prefab, unitPositionConfig.position, Quaternion.identity);
        return go;
    }
}
