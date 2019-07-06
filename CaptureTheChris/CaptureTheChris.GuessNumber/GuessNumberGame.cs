using CaptureTheChris.GameLogic;
using CaptureTheChris.Hangman;
using CaptureTheChris.Randomness;

namespace CaptureTheChris.GuessNumber
{
    public class GuessNumberGame : Game, IGame
    {
        private int? numberToGuess;
        private readonly IRandomNumberGenerator randomNumberGenerator;

        public GuessNumberGame(IRandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public override bool IsWon { get; protected set; }

        public override bool IsRunning { get; protected set; }

        public override void StartGame()
        {
            numberToGuess = randomNumberGenerator.GetRandomInteger(100);
            
            IsRunning = true;
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