using UnityEngine;


internal sealed class UnitAttackController
{
    public UnitConfig _unitConfigFrom;
    public UnitConfig _unitConfigTo;
    public UnitUIView _unitUIViewFrom;
    public UnitUIView _unitUIViewTo;

    public UnitAttackController()
    {
        _unitUIViewFrom = GameObject.FindObjectOfType<UnitUIView>();
        _unitUIViewTo = GameObject.FindObjectOfType<UnitUIView>();
    }
    public void Attack()
    {
        _unitConfigTo.health = _unitConfigTo.health - _unitConfigFrom.attackForce;
        _unitConfigFrom.isEnabled = false;

        _unitUIViewFrom.attackButton.gameObject.SetActive(false);
        _unitUIViewFrom.addBuffButton.gameObject.SetActive(false);
        _unitUIViewTo.hpSlider.value = _unitConfigTo.health;
        if(_unitConfigFrom.isEnabled == false)
        {
            _unitConfigTo.isEnabled = true;
            _unitUIViewTo.attackButton.gameObject.SetActive(true);
            _unitUIViewTo.addBuffButton.gameObject.SetActive(true);
        }
        else if (_unitConfigTo.isEnabled == false)
        {
            _unitUIViewFrom.attackButton.gameObject.SetActive(true);
            _unitUIViewFrom.addBuffButton.gameObject.SetActive(true);
        }
    }
    

    
}
