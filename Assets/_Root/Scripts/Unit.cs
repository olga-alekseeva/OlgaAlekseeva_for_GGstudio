using System.Collections.Generic;
using UnityEngine;

internal sealed class Unit
{
    public EventHandler<Unit> OnUnitAttack = new();
    public EventHandler<Unit> OnUnitBuffBressed = new();

    public UnitConfig unitConfig;
    private UnitUIView _unitUIView;

    public List<IBuff> _buffs = new();

    public UnitConfigBuff unitConfigBuff;

    public Unit(string configPath, string configPosPath, string uiParentPosPath)
    {
        unitConfig = Resources.Load<UnitConfig>(configPath);
        unitConfigBuff = new UnitConfigBuff(unitConfig);

        UnitViewFactory unitViewFactory = new UnitViewFactory();
        UnitPositionConfig unitPositionConfig = Resources.Load<UnitPositionConfig>(configPosPath);
        GameObject unit = unitViewFactory.InstantiateUnits(unitPositionConfig);
        Material unitMaterial = unit.GetComponent<Renderer>().material;
        unitMaterial.color = unitConfig.unitColor;


        GameObject UIPosPrefab = Resources.Load<GameObject>(uiParentPosPath);
        GameObject UIPosition = GameObject.Instantiate(UIPosPrefab);
        UnitUIPosition UIParentPos = UIPosition.GetComponent<UnitUIPosition>();
        UnitUIFactory unitUIFactory = new UnitUIFactory();
        _unitUIView = unitUIFactory.UnitUIInstantiator(UIParentPos.parentPosition);

        _unitUIView.attackButton.onClick.AddListener(OnAttackButtonPressed);
        _unitUIView.addBuffButton.onClick.AddListener(OnBuffButtonPressed);

        _unitUIView.hpSlider.value = unitConfig.health;
        _unitUIView.armorSlider.value = unitConfig.armor;
        _unitUIView.vampirismSlider.value = unitConfig.vampirism;
        _unitUIView.unitNameText.text = unitConfig.unitName;
        _unitUIView.attackForceText.text = $"Attack Force: " + unitConfig.attackForce.ToString();
    }

    public void UpdateUIData()
    {
        _unitUIView.hpSlider.value = unitConfigBuff.health;
        _unitUIView.armorSlider.value = unitConfigBuff.armor;
        _unitUIView.vampirismSlider.value = unitConfigBuff.vampirism;
    }

    public void OnAttackButtonPressed()
    {
        OnUnitAttack.Handle(this);
    }

    public void OnBuffButtonPressed()
    {
        OnUnitBuffBressed.Handle(this);
    }

    public void DisableUI()
    {
        _unitUIView.attackButton.gameObject.SetActive(false);
        _unitUIView.addBuffButton.gameObject.SetActive(false);
    }

    public void EndbleUI()
    {
        _unitUIView.attackButton.gameObject.SetActive(true);
        _unitUIView.addBuffButton.gameObject.SetActive(true);
    }

    public void AddBuff(IBuff buff)
    {
        _buffs.Add(buff);
        Debug.Log(buff.ID);
    }

    public void DecreaseBuffTime()
    {
        List<IBuff> buffsToRemove = new();

        foreach (IBuff buff in _buffs)
        {
            buff.SetRoundLeft(buff.RoundLeft - 1);
            if (buff.RoundLeft <= 0) buffsToRemove.Add(buff);
        }

        foreach (IBuff buff in buffsToRemove)
        {
            _buffs.Remove(buff);
        }
    }


}
