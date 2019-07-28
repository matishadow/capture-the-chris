namespace CaptureTheChris.GameLogic
{
    public interface IGame
    {
        bool IsWon { get; }
        bool IsRunning { get; }
        void StartGame();
        string GetFlag();
    }
}