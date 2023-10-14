using UnityEngine;

internal sealed class UnitManager
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
        CreateUnit(ResourcePathes.FIRST_UNIT_SETTINGS, ResourcePathes.FIRST_UNIT_POS, ResourcePathes.LEFT_UNIT_UI_POS);
        CreateUnit(ResourcePathes.SECOND_UNIT_SETTINGS, ResourcePathes.SECOND_UNIT_POS, ResourcePathes.RIGHT_UNIT_UI_POS);
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


        Material unitMaterial = unit.GetComponent<Renderer>().material;
        unitMaterial.color = unitConfig.unitColor;

        UnitUIViewController unitUIViewController = new UnitUIViewController();
        unitUIViewController.HPSetter(configPath);
        unitUIViewController.NameSetter(configPath);
        unitUIViewController.AttackForceSetter(configPath);
    }
   
}

