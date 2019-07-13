namespace CaptureTheChris.ProjectEuler
{
    public interface IProjectEulerGame
    {
        bool IsWon { get; }
        bool IsRunning { get; }
        void StartGame();
        bool TryProvideAnswer(string answer);
        string GetFlag();
    }
}