namespace CaptureTheChris.GuessNumber
{
    public interface IGuessNumberGame
    {
        bool IsWon { get; }
        bool IsRunning { get; }
        void StartGame();
        string GetFlag();
        bool TryGuess(int number);
    }
}