using UnityEngine;

public class RoundCounter
{
    private int roundCount = 1;

    private GameUIView _gameUIView;

    public void SwitchRound()
    {
        _gameUIView = GameObject.FindObjectOfType<GameUIView>();
        for (int i = 2; i > roundCount; i++)
        {
            roundCount++;
        }
        _gameUIView.roundCounterText.text = $"Round: " + roundCount;
    }
}
