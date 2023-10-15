using System;
using UnityEngine;

internal sealed class UnitUIViewController
{
    private UnitUIView _unitUIView;
    private UnitConfig _unitConfig;
    
    public UnitUIViewController()
    {
        _unitUIView = GameObject.FindObjectOfType<UnitUIView>();     
    }
    public void SetPath(string configPath)
    {
        _unitConfig = Resources.Load<UnitConfig>(configPath);
    }
    public void HPSetter(string configPath)
    {
        SetPath(configPath);
        _unitUIView.hpSlider.value = _unitConfig.health;
    }

    public void NameSetter(string configPath)
    {
        SetPath(configPath);
        _unitUIView.unitNameText.text = _unitConfig.unitName;
    }
    public void AttackForceSetter(string configPath)
    {
        SetPath(configPath);
        _unitUIView.attackForceText.text = $"Attack force: " + _unitConfig.attackForce.ToString();
    }
    
  
   
}
