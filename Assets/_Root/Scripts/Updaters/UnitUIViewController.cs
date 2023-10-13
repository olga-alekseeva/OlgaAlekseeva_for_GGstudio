using UnityEngine;

internal sealed class UnitUIViewController
{
    private UnitUIView _unitUIView;
    private UnitConfig _unitConfig;

    public UnitUIViewController()
    {
        _unitUIView = GameObject.FindObjectOfType<UnitUIView>();
       
    }

    public void HPSetter(string configPath)
    {
        _unitConfig = Resources.Load<UnitConfig>(configPath);
        _unitUIView.hpSlider.value = _unitConfig.health;

    }
       

}
