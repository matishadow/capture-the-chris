using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CaptureTheChris.Enums;
using CaptureTheChris.GameLogic;
using CaptureTheChris.Interfaces.SimonSays;
using CaptureTheChris.Randomness;

namespace CaptureTheChris.SimonSays
{
    public class SimonSaysGame : Game, IGame
    {
        private readonly IRandomColorGenerator randomColorGenerator;
        private const int NumberOfRounds = 30;

        private SimonSaysColor[] simonSaysColors;
        private int roundNumber;

        public SimonSaysGame(IRandomColorGenerator randomColorGenerator) 
            : base(Flags.Properties.Resources.FlagSimonSays)
        {
            this.randomColorGenerator = randomColorGenerator;
        }

        public IEnumerable<SimonSaysColor> GetColorsToRemember()
        {
            CheckRunningGame();

            return simonSaysColors.Take(roundNumber);
        }

        public void TurnRound(IList<SimonSaysColor> colors)
        {
            CheckRunningGame();
            
            if (colors == null)
                throw new ArgumentNullException();
            if (!colors.Any() || colors.Count > simonSaysColors.Length)
                throw new ArgumentOutOfRangeException();

            if (colors.Where((gameColor, i) => gameColor != simonSaysColors[i]).Any())
            {
                IsRunning = false;
                roundNumber = 0;
                return;
            }
            
            roundNumber++;
            if (roundNumber > NumberOfRounds)
                IsWon = true;
        }

        public override bool IsWon { get; protected set; }
        public override bool IsRunning { get; protected set; }
        public override void StartGame()
        {
            IsRunning = true;
            IsWon = false;
            roundNumber = 1;
            
            simonSaysColors = new SimonSaysColor[NumberOfRounds];
            for (var i = 0; i < simonSaysColors.Length; i++)
                simonSaysColors[i] = randomColorGenerator.GetRandomColor<SimonSaysColor>();
        }
    }
}