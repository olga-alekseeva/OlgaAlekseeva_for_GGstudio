using System;
using UnityEngine;
using UnityEngine.UI;

internal sealed class UnitView : MonoBehaviour, IDestroyable
{
    public Transform parentTransform;
    public Slider hpSlider;
    public Slider armorSlider;
    public Slider vampirismSlider;

    public event Action ActionOnDestroy = delegate { };
    private void OnDestroy()
    {
        ActionOnDestroy.Invoke();
    }
}
