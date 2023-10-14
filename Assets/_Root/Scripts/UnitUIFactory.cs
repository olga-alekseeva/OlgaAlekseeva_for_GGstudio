using UnityEngine;

internal sealed class UnitUIFactory
{
    private GameObject _uiPrefab;

    public UnitUIFactory()
    {
        _uiPrefab = Resources.Load<GameObject>("Prefabs/UI/UIPanel");
    }

    public UnitUIView UnitUIInstantiator(Transform parent)
    {
        GameObject go = GameObject.Instantiate(_uiPrefab, parent);
        return go.GetComponent<UnitUIView>();
    }
}
