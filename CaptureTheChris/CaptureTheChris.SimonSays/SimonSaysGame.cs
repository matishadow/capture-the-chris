using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CaptureTheChris.Enums;
using CaptureTheChris.GameLogic;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using CaptureTheChris.Randomness;

namespace CaptureTheChris.SimonSays
{
    public class SimonSaysGame : Game, IGame, 
        IAsImplementedInterfacesDependency, ISingleInstanceDependency, ISimonSaysGame
    {
        private readonly IRandomColorGenerator randomColorGenerator;
        private const int NumberOfRounds = 10;

        private SimonSaysColor[] simonSaysColors;

        public SimonSaysGame(IRandomColorGenerator randomColorGenerator) 
            : base(Flags.Properties.Resources.FlagSimonSays)
        {
            this.randomColorGenerator = randomColorGenerator;
        }

        public IEnumerable<SimonSaysColor> GetColorsToRemember()
        {
            CheckRunningGame();

            return simonSaysColors.Take(RoundNumber);
        }

        public void TurnRound(IList<SimonSaysColor> colors)
        {
            CheckRunningGame();
            
            if (colors == null)
                throw new ArgumentNullException();
            if (!colors.Any() || colors.Count > simonSaysColors.Length)
                throw new ArgumentOutOfRangeException();
            if (colors.Count != RoundNumber)
                throw new ArgumentOutOfRangeException();

            if (colors.Where((gameColor, i) => gameColor != simonSaysColors[i]).Any())
            {
                RoundNumber = 1;
                return;
            }
            
            RoundNumber++;
            if (RoundNumber > NumberOfRounds)
                IsWon = true;
        }

        public override bool IsWon { get; protected set; }
        public override bool IsRunning { get; protected set; }

        public int RoundNumber { get; private set; }

        public override void StartGame()
        {
            IsRunning = true;
            IsWon = false;
            RoundNumber = 1;
            
            simonSaysColors = new SimonSaysColor[NumberOfRounds];
            for (var i = 0; i < simonSaysColors.Length; i++)
                simonSaysColors[i] = randomColorGenerator.GetRandomColor<SimonSaysColor>();
        }
    }
}