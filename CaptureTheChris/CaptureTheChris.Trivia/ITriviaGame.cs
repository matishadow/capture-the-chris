using System.Collections.Generic;

namespace CaptureTheChris.Trivia
{
    public interface ITriviaGame
    {
        bool IsWon { get; }
        bool IsRunning { get; }
        IList<string> Questions { get; }
        void StartGame();
        bool TryAnswer(IList<string> answers);
        bool TryAnswer(IList<string> answers, out IList<QuestionResult> questionResults);
        string GetFlag();
    }
}