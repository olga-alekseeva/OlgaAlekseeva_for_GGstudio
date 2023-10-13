using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUIFactory 
{
    private GameObject _uiPrefab;

    public UnitUIFactory()

    {
        _uiPrefab = Resources.Load<GameObject>("Prefabs/UI/UIPanel"); 
    }

    public void UnitUIInstantiator(Transform parent)///Здесь можно переписать void На имя класса в котором будет вью Ui и вернуть его
    {
        GameObject go = GameObject.Instantiate(_uiPrefab, parent);


    }
}
