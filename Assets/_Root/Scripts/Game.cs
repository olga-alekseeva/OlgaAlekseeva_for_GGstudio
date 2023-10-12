namespace Testwork.Starter
{
    internal sealed class Game

    {
        private UpdateController _updateController;
        internal void Start()
        {
            _updateController = new UpdateController();

        }
        public void Update(float deltaTime)
        {
        }
    }
}