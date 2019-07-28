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

        protected readonly string Flag;

        protected Game(string flag)
        {
            Flag = flag;
        }

        public abstract bool IsWon { get; protected set; }
        public abstract bool IsRunning { get; protected set; }
        public abstract void StartGame();

        public virtual string GetFlag()
        {
            return IsWon ? Flag : string.Empty;
        }
    }
}