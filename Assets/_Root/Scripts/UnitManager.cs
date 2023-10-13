using UnityEngine;

public class UnitManager
{
    private UnitViewFactory _unitViewFactory;
    private UnitUIFactory _unitUIFactory;

    public UnitManager()
    {
        _unitViewFactory = new UnitViewFactory();
        _unitUIFactory = new UnitUIFactory();
    }

    public void OnStartGame()
    {
        CreateUnits();
    }

    private void CreateUnits()
    {
        CreateUnit(ResourcePathes.FIRST_UNIT_SETTINGS, ResourcePathes.FIRST_UNIT_POS, "Prefabs/UI/ParentLeftUITransform");
        CreateUnit(ResourcePathes.SECOND_UNIT_SETTINGS, ResourcePathes.SECOND_UNIT_POS, "Prefabs/UI/ParentRightUITransform");
    }

    private void CreateUnit(string configPath, string configPosPath, string uiParentPosPath)
    {
        UnitConfig unitConfig = Resources.Load<UnitConfig>(configPath);

        UnitPositionConfig unitPositionConfig = Resources.Load<UnitPositionConfig>(configPosPath);
        GameObject unit = _unitViewFactory.InstantiateUnits(unitPositionConfig);


        GameObject UIPosPrefab = Resources.Load<GameObject>(uiParentPosPath);
        GameObject UIPosition = GameObject.Instantiate(UIPosPrefab);
        UnitUIPosition UIParentPos = UIPosition.GetComponent<UnitUIPosition>();
        _unitUIFactory.UnitUIInstantiator(UIParentPos.parentPosition);
    }
}

