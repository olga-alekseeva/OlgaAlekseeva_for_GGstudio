using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


internal sealed class UnitUIManager
{
    private UnitUIView _unitUIView;
    public UnitConfigBuff unitConfigBuff;
    public UnitConfig unitConfig;

    public EventHandler<UnitUIManager> OnUnitAttack = new();
    public EventHandler<UnitUIManager> OnUnitBuffBressed = new();
    public List<IBuff> _buffs = new();



    public UnitUIManager(string uiParentPosPath)
    {
        _unitUIView = GameObject.FindObjectOfType<UnitUIView>();
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

        _unitUIView.hpCounter.text = unitConfig.health.ToString();
        _unitUIView.armorCounter.text = unitConfig.armor.ToString();
        _unitUIView.vampirismCounter.text = unitConfig.vampirism.ToString();
        _unitUIView.attackForceText.text = $"Attack Force: " + unitConfig.attackForce.ToString();
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
    public void UpdateUIData()
    {
        _unitUIView.hpSlider.value = unitConfigBuff.health;
        _unitUIView.armorSlider.value = unitConfigBuff.armor;
        _unitUIView.vampirismSlider.value = unitConfigBuff.vampirism;

        _unitUIView.hpCounter.text = unitConfigBuff.health.ToString();
        _unitUIView.armorCounter.text = unitConfigBuff.armor.ToString();
        _unitUIView.vampirismCounter.text = unitConfigBuff.vampirism.ToString();
        _unitUIView.attackForceText.text = $"Attack Force: " + unitConfigBuff.attackForce.ToString();

        UpdateUIBuff();
    }
    public void UpdateUIBuff()
    {
        BuffIconsSetActive(false);
        foreach (IBuff buff in _buffs)
        {
            BuffIconSetActive(buff, true);
        }
    }

    public void OnAttackButtonPressed()
    {
        OnUnitAttack.Handle(this);
    }
    public void OnBuffButtonPressed()
    {
        OnUnitBuffBressed.Handle(this);
        _unitUIView.addBuffButton.gameObject.SetActive(false);
    }
    public void BuffIconsSetActive(bool activeValue)
    {
        _unitUIView.doubleBuffIcon.gameObject.SetActive(activeValue);
        _unitUIView.ArmorSelfBuffIcon.gameObject.SetActive(activeValue);
        _unitUIView.ArmorDestructionBuffIcon.gameObject.SetActive(activeValue);
        _unitUIView.VampirismSelfBuffBuffIcon.gameObject.SetActive(activeValue);
        _unitUIView.VampirismDecreaseBuffIcon.gameObject.SetActive(activeValue);
    }
    public void BuffIconSetActive(IBuff buff, bool activeValue)
    {
        if (buff.ID == 0)
        {
            _unitUIView.doubleBuffIcon.gameObject.SetActive(activeValue);
            _unitUIView.doubleBuffRoundsLeftText.text = buff.RoundLeft.ToString();
        }
        if (buff.ID == 1)
        {
            _unitUIView.ArmorSelfBuffIcon.gameObject.SetActive(activeValue);
            _unitUIView.ArmorSelfBuffRoundsLeftText.text = buff.RoundLeft.ToString();
        }
        if (buff.ID == 2)
        {
            _unitUIView.ArmorDestructionBuffIcon.gameObject.SetActive(activeValue);
            _unitUIView.ArmorDestructionBuffRoundsLeftText.text = buff.RoundLeft.ToString();
        }
        if (buff.ID == 3)
        {
            _unitUIView.VampirismSelfBuffBuffIcon.gameObject.SetActive(activeValue);
            _unitUIView.VampirismSelfBuffRoundsLeftText.text = buff.RoundLeft.ToString();
        }
        if (buff.ID == 4)
        {
            _unitUIView.VampirismDecreaseBuffIcon.gameObject.SetActive(activeValue);
            _unitUIView.VampirismDecreaseBuffRoundsLeftText.text = buff.RoundLeft.ToString();
        }
    }
    public void AddBuff(IBuff buff)
    {
        _buffs.Add(buff);
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
    public void OnStartGame()
    {


    }

}
