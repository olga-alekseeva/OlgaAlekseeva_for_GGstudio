using System.Collections;
using UnityEngine;

    internal sealed class RoundCounterManager 
    {
    private GameUIView _gameUIView;
    private int roundCounterNumber;
    public void OnStartGame()
    {
        _gameUIView = GameObject.FindObjectOfType<GameUIView>();
        roundCounterNumber = 1;
        _gameUIView.roundCounterText.text = $"Round " + roundCounterNumber;
    }

        
    }

