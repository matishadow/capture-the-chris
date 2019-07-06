using CaptureTheChris.GameLogic;
using Resources = CaptureTheChris.Trivia.Properties.Resources;

namespace CaptureTheChris.Trivia
{
    public class TriviaGame : Game, IGame
    {
        public TriviaGame() : base(Data.Properties.Resources.FlagTrivia)
        {
        }

        public override bool IsWon { get; protected set; }
        public override bool IsRunning { get; protected set; }

        public override void StartGame()
        {
            IsRunning = true;
            IsWon = false;
        }

        public void Answer(TriviaAnswers triviaAnswers)
        {
            if (triviaAnswers.Answer1 != Resources.Answer1 || triviaAnswers.Answer2 != Resources.Answer2 ||
                triviaAnswers.Answer3 != Resources.Answer3 || triviaAnswers.Answer4 != Resources.Answer4 ||
                triviaAnswers.Answer5 != Resources.Answer5 || triviaAnswers.Answer6 != Resources.Answer6 ||
                triviaAnswers.Answer7 != Resources.Answer7 || triviaAnswers.Answer8 != Resources.Answer8 ||
                triviaAnswers.Answer9 != Resources.Answer9 || triviaAnswers.Answer10 != Resources.Answer10) return;
            
            IsWon = true;
            IsRunning = false;
        }
    }
}