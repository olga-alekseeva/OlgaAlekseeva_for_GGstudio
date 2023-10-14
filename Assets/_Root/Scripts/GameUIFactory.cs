using UnityEngine;

internal sealed class GameUIFactory
{
    private GameObject _uiPrefab;

    public GameUIFactory()
    {
        _uiPrefab = Resources.Load<GameObject>(ResourcePathes.GAME_UI_OBJ);
    }
    public GameUIView GameUIInstantiator()
    {
        GameObject go = Object.Instantiate(_uiPrefab);
        return go.GetComponent<GameUIView>();
    }
}
