namespace Testwork.Starter
{
    internal sealed class Game
    {
        private UpdateController _updateController;
        private EventHandler _onStartGame;
        private EventHandler _onStartFirstRound = new();

        public Game()
        {
            _updateController = new UpdateController();
            _onStartGame = new EventHandler();

            GameUIManager gameUIManager = new GameUIManager();
            _onStartGame.AddHandler(gameUIManager.OnStartGame);

            UnitManager unitManager = new UnitManager();
            _onStartGame.AddHandler(unitManager.OnStartGame);

            MoveSwitcher moveSwitcher = new MoveSwitcher();
            unitManager.OnUnitCreated.AddHandler(moveSwitcher.OnUnitCreated);
            moveSwitcher.OnUnitStartMove.AddHandler(unitManager.OnUnitStartMove);

            _onStartFirstRound.AddHandler(moveSwitcher.FirstRoundStarted);

            UnitAttackController unitAttackController = new UnitAttackController();
            unitManager.OnUnitAttacking.AddHandler(unitAttackController.OnUnitAttacking);
            unitAttackController.OnUnitAttacked.AddHandler(unitManager.OnUnitAttacked);

            EndMoveController endMoveController = new EndMoveController();
            unitAttackController.OnAttacked.AddHandler(endMoveController.EndCurrentMove);
            endMoveController.OnEndCurrentMove.AddHandler(moveSwitcher.NextMove);

            RoundController roundController = new RoundController();
            unitManager.OnUnitCreated.AddHandler(roundController.OnUnitCreated);
            moveSwitcher.OnUnitStartMove.AddHandler(roundController.OnUnitStartMove);
            _onStartGame.AddHandler(roundController.OnStartGame);

            BuffManager buffManager = new BuffManager();
            unitManager.OnUnitBuffPressedEvent.AddHandler(buffManager.ButtonBuffPressed);
            buffManager.OnUnitChooseBuff.AddHandler(unitManager.OnUnitChooseBuff);

            UnitKilledController unitKilledController = new UnitKilledController();
            unitAttackController.OnUnitDied.AddHandler(unitKilledController.OnUnitDied);
        }

        internal void Start()
        {
            _onStartGame.Handle();
            _onStartFirstRound.Handle();
        }
        public void Update(float deltaTime)
        {
            _updateController.Update(deltaTime);
        }
    }
}