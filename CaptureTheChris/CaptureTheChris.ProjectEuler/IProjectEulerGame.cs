namespace CaptureTheChris.ProjectEuler
{
    public interface IProjectEulerGame
    {
        bool IsWon { get; }
        bool IsRunning { get; }
        void StartGame();
        void ProvideAnswer(string answer);
        string GetFlag();
    }
}