namespace Testwork.Starter
{
    internal sealed class Game

    {
        private UpdateController _updateController;
        internal void Start()
        {
            _updateController = new UpdateController();
            EventHandler OnStartScene = new EventHandler();


        }
        public void Update(float deltaTime)
        {
            _updateController.Update(deltaTime);
        }
    }
}