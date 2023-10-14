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
        UnitAttackController unitAttackController1 = CreateUnit(ResourcePathes.FIRST_UNIT_SETTINGS, ResourcePathes.FIRST_UNIT_POS, ResourcePathes.LEFT_UNIT_UI_POS);
        UnitAttackController unitAttackController2 = CreateUnit(ResourcePathes.SECOND_UNIT_SETTINGS, ResourcePathes.SECOND_UNIT_POS, ResourcePathes.RIGHT_UNIT_UI_POS);
        unitAttackController1._unitConfigTo = unitAttackController2._unitConfigFrom;
        unitAttackController2._unitConfigTo = unitAttackController1._unitConfigFrom;
        unitAttackController1._unitUIViewTo = unitAttackController2._unitUIViewFrom;
        unitAttackController2._unitUIViewTo = unitAttackController1._unitUIViewFrom;
    }

    private UnitAttackController CreateUnit(string configPath, string configPosPath, string uiParentPosPath)
    {
        UnitConfig unitConfig = Resources.Load<UnitConfig>(configPath);

        UnitPositionConfig unitPositionConfig = Resources.Load<UnitPositionConfig>(configPosPath);
        GameObject unit = _unitViewFactory.InstantiateUnits(unitPositionConfig);

        GameObject UIPosPrefab = Resources.Load<GameObject>(uiParentPosPath);
        GameObject UIPosition = GameObject.Instantiate(UIPosPrefab);
        UnitUIPosition UIParentPos = UIPosition.GetComponent<UnitUIPosition>();
        
        UnitUIView unitUIView = _unitUIFactory.UnitUIInstantiator(UIParentPos.parentPosition);


        Material unitMaterial = unit.GetComponent<Renderer>().material;
        unitMaterial.color = unitConfig.unitColor;

        UnitUIViewController unitUIViewController = new UnitUIViewController();
        unitUIViewController.HPSetter(configPath);
        unitUIViewController.NameSetter(configPath);
        unitUIViewController.AttackForceSetter(configPath);

        UnitAttackController unitAttackController = new UnitAttackController();
        unitAttackController._unitConfigFrom = unitConfig;
        unitAttackController._unitUIViewFrom = unitUIView;
        unitUIView.attackButton.onClick.AddListener(unitAttackController.Attack);
        //RoundCounter roundCounter = new RoundCounter();
        //roundCounter.SwitchRound();
        return unitAttackController;
    }


   
}

