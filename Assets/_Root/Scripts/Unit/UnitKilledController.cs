using UnityEngine;
using UnityEngine.SceneManagement;

internal sealed class UnitKilledController
{
    public void OnUnitDied(Unit unit)
    {       
            SceneManager.LoadScene(0);       
    }
}

