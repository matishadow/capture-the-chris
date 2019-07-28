using System;
using System.Collections.Generic;
using System.Linq;
using CaptureTheChris.Enums;
using CaptureTheChris.GameLogic;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using CaptureTheChris.Randomness;

namespace CaptureTheChris.Enigma
{
    public class EnigmaGame : Game, IGame, IEnigmaGame,
        ISingleInstanceDependency, IAsImplementedInterfacesDependency
    {
        private const int MaxNumberOfTries = 6; // might need to be tweaked to 5
        private EnigmaField[] enigmaFields = new EnigmaField[4];
        public IList<EnigmaGuessResult> Tries { get; } = new List<EnigmaGuessResult>();

        private readonly IRandomColorGenerator randomColorGenerator;

        public EnigmaGame(IRandomColorGenerator randomColorGenerator) : base(Flags.Properties.Resources.FlagEnigma)
        {
            this.randomColorGenerator = randomColorGenerator;
        }

        public int CurrentNumberOfTries { get; private set; }

        public override bool IsWon { get; protected set; }
        public override bool IsRunning { get; protected set; }

        public override void StartGame()
        {
            IsWon = false;
            IsRunning = true;

            Tries.Clear();
            enigmaFields = new EnigmaField[4];
            SetRandomColors();
            ResetTries();
        }

        public EnigmaGuessResult GuessColors(EnigmaColor[] colors)
        {
            CheckRunningGame();
            var guessResult = new EnigmaGuessResult();

            if (colors == null || colors.Length != enigmaFields.Length)
                throw new ArgumentException($"Input must be of size {enigmaFields.Length}");

            for (var i = 0; i < enigmaFields.Length; i++)
            {
                guessResult.tries[i] = new EnigmaField(colors[i], enigmaFields[i].Guess(colors[i]));
            }

            Tries.Add(guessResult);

            if (AllColorsGuessed())
            {
                IsRunning = false;
                IsWon = true;
            }
            else
            {
                CurrentNumberOfTries -= 1;

                if (CurrentNumberOfTries >= 1) return guessResult;
                IsRunning = false;
                IsWon = false;
            }

            return guessResult;
        }

        private void SetRandomColors()
        {
            for (var i = 0; i < enigmaFields.Length; i++)
            {
                var randomColor = randomColorGenerator.GetRandomColor<EnigmaColor>();

                while (enigmaFields.Any(field => field != null && field.EnigmaColor == randomColor))
                    randomColor = randomColorGenerator.GetRandomColor<EnigmaColor>();

                enigmaFields[i] = new EnigmaField(randomColor);
            }
        }

        private void ResetTries()
        {
            CurrentNumberOfTries = MaxNumberOfTries;
        }

        private bool AllColorsGuessed()
        {
            return enigmaFields.All(field => field.IsGuessed);
        }
    }
}