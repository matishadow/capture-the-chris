using CaptureTheChris.GameLogic;
using CaptureTheChris.Hangman;
using CaptureTheChris.Randomness;

namespace CaptureTheChris.GuessNumber
{
    public class GuessNumberGame : Game, IGame
    {
        private int? numberToGuess;
        private readonly IRandomNumberGenerator randomNumberGenerator;
        private bool isWon;

        public GuessNumberGame(IRandomNumberGenerator randomNumberGenerator)
            : base(Flags.Properties.Resources.FlagGuessNumber)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public override bool IsWon
        {
            get => isWon;
            protected set
            {
                isWon = value;
                Flags.Properties.Settings.Default.IsGuessNumberWon = true;
            }
        }

        public override bool IsRunning { get; protected set; }

        public override void StartGame()
        {
            numberToGuess = randomNumberGenerator.GetRandomInteger(100);

            IsRunning = true;
        }

        public override string GetFlag()
        {
            return IsWon ? CaptureTheChris.Flags.Properties.Resources.FlagGuessNumber : string.Empty;
        }

        public void Guess(int number)
        {
            if (number != numberToGuess) return;

            IsWon = true;
            numberToGuess = null;
            IsRunning = false;
        }
    }
}