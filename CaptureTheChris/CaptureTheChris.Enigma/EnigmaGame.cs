using CaptureTheChris.GameLogic;
using CaptureTheChris.Randomness;

namespace CaptureTheChris.Enigma
{
    public class EnigmaGame : Game, IGame
    {
        private const int MaxNumberOfTries = 6;

        private readonly IRandomNumberGenerator randomNumberGenerator;
        
        public EnigmaGame(IRandomNumberGenerator randomNumberGenerator) : base(Flags.Properties.Resources.FlagEnigma)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public override bool IsWon { get; protected set; }
        public override bool IsRunning { get; protected set; }
        public override void StartGame()
        {
            throw new System.NotImplementedException();
        }
    }
}