using System;
using System.Collections.Generic;
using System.Linq;
using CaptureTheChris.Enums;
using CaptureTheChris.GameLogic;
using CaptureTheChris.Randomness;

namespace CaptureTheChris.Enigma
{
    public class EnigmaGame : Game, IGame
    {
        private const int MaxNumberOfTries = 6; // might need to be tweaked to 5
        private readonly EnigmaField[] enigmaFields = new EnigmaField[4];
        private int currentNumberOfTries;

        private readonly IRandomColorGenerator randomColorGenerator;

        public EnigmaGame(IRandomColorGenerator randomColorGenerator) : base(Flags.Properties.Resources.FlagEnigma)
        {
            this.randomColorGenerator = randomColorGenerator;
        }

        public override bool IsWon { get; protected set; }
        public override bool IsRunning { get; protected set; }
        public override void StartGame()
        {
            IsWon = false;
            IsRunning = true;
            
            SetRandomColors();
            ResetTries();
        }

        public void GuessColors(EnigmaColor[] colors)
        {
           if (colors.Length != enigmaFields.Length)
               throw new ArgumentException($"Input must be of size {enigmaFields.Length}");

           for (var i = 0; i < enigmaFields.Length; i++)
               enigmaFields[i].Guess(colors[i]);

           if (AllColorsGuessed())
           {
               IsRunning = false;
               IsWon = true;
           }
           else
           {
               currentNumberOfTries -= 1;

               if (currentNumberOfTries >= 1) return;
               IsRunning = false;
               IsWon = false;
           }
        }

        private void SetRandomColors()
        {
            for (var i = 0; i < enigmaFields.Length; i++)
                enigmaFields[i] = new EnigmaField(randomColorGenerator.GetRandomColor<EnigmaColor>());
        }

        private void ResetTries()
        {
            currentNumberOfTries = MaxNumberOfTries;
        }

        private bool AllColorsGuessed()
        {
            return enigmaFields.All(field => field.IsGuessed);
        }
    }
}