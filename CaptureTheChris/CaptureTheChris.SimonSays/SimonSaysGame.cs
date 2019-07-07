using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CaptureTheChris.Enums;
using CaptureTheChris.Interfaces.SimonSays;

namespace CaptureTheChris.SimonSays
{
    public class SimonSaysGame 
    {
        private readonly ISimonSaysColorGenerator simonSaysColorGenerator;

        private SimonSaysColor[] simonSaysColors;
        private int roundNumber;

        public SimonSaysGame(ISimonSaysColorGenerator simonSaysColorGenerator)
        {
            this.simonSaysColorGenerator = simonSaysColorGenerator;
        }

        private bool IsGameRunning => simonSaysColors != null;

        public bool StartGame(int numberOfRounds)
        {
            if (IsGameRunning)
                throw new InvalidOperationException(); 
            
            if (numberOfRounds <= 0)
                throw new ArgumentOutOfRangeException();

            roundNumber = 1;
            simonSaysColors = new SimonSaysColor[numberOfRounds];
            for (var i = 0; i < simonSaysColors.Length; i++)
                simonSaysColors[i] = simonSaysColorGenerator.GetRandomColor();

            return true;
        }

        public bool StopGame()
        {
            if (!IsGameRunning)
                throw new InvalidOperationException(); 
            
            simonSaysColors = null;
            roundNumber = 0;
            
            return true;
        }

        public IEnumerable<SimonSaysColor> GetColorsToRemember()
        {
            if (!IsGameRunning)
                throw new InvalidOperationException();

            return simonSaysColors.Take(roundNumber);
        }

        public bool TurnRound(IList<SimonSaysColor> colors)
        {
            if (!IsGameRunning)
                throw new InvalidOperationException();
            if (colors == null)
                throw new ArgumentNullException();
            if (!colors.Any() || colors.Count > simonSaysColors.Length)
                throw new ArgumentOutOfRangeException();

            if (colors.Where((gameColor, i) => gameColor != simonSaysColors[i]).Any())
                return false;
            
            roundNumber++;
            return true;
        }
    }
}