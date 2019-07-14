namespace CaptureTheChris.Hangman
{
    public interface IHangmanGame
    {
        bool IsWon { get; }
        bool IsRunning { get; }
        int Tries { get; }
        void StartGame();
        bool TryGuess(char guess);
        bool TryGuess(string guess);
        string GetVisiblePhase();
        string GetFlag();
    }
}