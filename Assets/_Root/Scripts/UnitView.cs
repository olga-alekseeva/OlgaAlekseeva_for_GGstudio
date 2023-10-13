using System;
using UnityEngine;
using UnityEngine.UI;

internal sealed class UnitView : MonoBehaviour, IDestroyable
{
    public Transform parentTransform;

    public event Action ActionOnDestroy = delegate { };
    private void OnDestroy()
    {
        ActionOnDestroy.Invoke();
    }
}
