using System;

namespace CaptureTheChris.GameLogic
{
    public abstract class Game : IGame
    {
        protected void CheckRunningGame()
        {
            if (!IsRunning)
                throw new InvalidOperationException("Cannot play when game is not running.");
        }

        public abstract bool IsWon { get; protected set; }
        public abstract bool IsRunning { get; protected set; }
        public abstract void StartGame();
    }
}