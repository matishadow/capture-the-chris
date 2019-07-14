using System;
using CaptureTheChris.GameLogic;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;

namespace CaptureTheChris.Hangman
{
    public class HangmanGame : Game, IGame,
        ISingleInstanceDependency, IAsImplementedInterfacesDependency
    {
        private readonly IRandomWordGenerator randomWordGenerator;
        private int tries;

        private IPhaseToGuess phaseToGuess;

        public override bool IsWon { get; protected set; }

        public override bool IsRunning { get; protected set; }

        public int Tries
        {
            get => tries;
            private set
            {
                if (value < 0) 
                    throw new InvalidOperationException("Tries must be a positive number.");

                tries = value;

                if (tries == 0)
                    IsRunning = false;
            }
        }


        public HangmanGame(IRandomWordGenerator randomWordGenerator) : base(Flags.Properties.Resources.FlagHangman)
        {
            this.randomWordGenerator = randomWordGenerator;
        }

        public override void StartGame()
        {
            string generatedWord = randomWordGenerator.GetRandomWord();
            
            phaseToGuess = new PhaseToGuess(generatedWord);
            Tries = 7;
            IsRunning = true;
        }

        public bool Guess(char guess) 
        {
            return GuessInternal(guess);
        }
        
        public bool Guess(string guess) 
        {
            return GuessInternal(guess);
        }

        public string GetVisiblePhase()
        {
            return phaseToGuess.GetVisiblePhase();
        }

        private bool GuessInternal(dynamic guess)
        {
            CheckRunningGame();

            bool wasGuessSuccessful = phaseToGuess.TryGuessing(guess);

            if (!wasGuessSuccessful)
                Tries -= 1;
            else if (phaseToGuess.AreAllLettersGuessed())
                IsWon = true;

            return wasGuessSuccessful;
        }
        
    }
}