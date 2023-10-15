using UnityEngine;
using UnityEngine.SceneManagement;


internal sealed class GameUIManager
{
    private GameUIView _gameUIView;
    private GameUIFactory _gameUIFactory;
    public GameUIManager()
    {
        _gameUIFactory = new GameUIFactory();
    }
    public void OnStartGame()
    {
        CreateGameUI();
        _gameUIView = GameObject.FindObjectOfType<GameUIView>();
        RestartGameButton();
    }

    private void CreateGameUI()
    {
        _gameUIFactory.GameUIInstantiator();
    }

    public void RestartGameButton()
    {
        _gameUIView.restartGameButton.onClick.AddListener(RestartGame);

    }
    private void RestartGame()
    {
        SceneManager.LoadScene(0);

    }
}
