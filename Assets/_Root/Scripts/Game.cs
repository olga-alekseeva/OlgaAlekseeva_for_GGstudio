using UnityEngine;

namespace Testwork.Starter
{
    internal sealed class Game

    {
        private UpdateController _updateController;
        private EventHandler _onStartGame;

        public Game()
        {

            _updateController = new UpdateController();
           _onStartGame = new EventHandler();

            UnitManager unitManager = new UnitManager();
            _onStartGame.AddHandler(unitManager.OnStartGame);

            GameUIManager gameUIManager = new GameUIManager();
            _onStartGame.AddHandler(gameUIManager.OnStartGame);

            RoundCounterManager roundCounterManager = new RoundCounterManager();
            _onStartGame.AddHandler(roundCounterManager.OnStartGame);
        }

        internal void Start()
        {
            _onStartGame.Handle();

        }
        public void Update(float deltaTime)
        {
            _updateController.Update(deltaTime);
        }
    }
}