using System.Collections.Generic;
using UnityEngine;

internal sealed class RoundController
{
    private List<Unit> unitList = new List<Unit>();
    private GameUIView _gameUIView;

    private int _round = 0;

    public void OnStartGame()
    {
        _gameUIView = GameObject.FindObjectOfType<GameUIView>();
    }

    public void OnUnitCreated(Unit unit)
    {
        unitList.Add(unit);
    }

    public void OnUnitStartMove(Unit unit)
    {
        if (unit == unitList[0])
        {
            NewRound();
        }
    }

    public void NewRound()
    {
        _round++;
        UpdateRoundCounter();
    }

    public void UpdateRoundCounter()
    {
        _gameUIView.roundCounterText.text = $"Round: " + _round;
    }
}
