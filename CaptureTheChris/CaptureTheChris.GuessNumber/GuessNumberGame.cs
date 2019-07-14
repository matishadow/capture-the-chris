using CaptureTheChris.GameLogic;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using CaptureTheChris.Randomness;

namespace CaptureTheChris.GuessNumber
{
    public class GuessNumberGame : Game, IGame, IGuessNumberGame,
        ISingleInstanceDependency, IAsImplementedInterfacesDependency
    {
        private int? numberToGuess;
        private readonly IRandomNumberGenerator randomNumberGenerator;

        public GuessNumberGame(IRandomNumberGenerator randomNumberGenerator)
            : base(Flags.Properties.Resources.FlagGuessNumber)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public override bool IsWon { get; protected set; }

        public override bool IsRunning { get; protected set; }

        public override void StartGame()
        {
            numberToGuess = randomNumberGenerator.GetRandomInteger(100);

            IsRunning = true;
            IsWon = false;
        }

        public override string GetFlag()
        {
            return IsWon ? Flag : string.Empty;
        }

        public bool TryGuess(int number)
        {
            if (number != numberToGuess) return false;

            IsWon = true;
            numberToGuess = null;
            IsRunning = false;

            return true;
        }
    }
}