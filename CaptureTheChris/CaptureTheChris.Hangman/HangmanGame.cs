using System;

namespace CaptureTheChris.Hangman
{
    public class HangmanGame
    {
        private readonly IRandomWordGenerator randomWordGenerator;
        private int tries;
        
        private IPhaseToGuess phaseToGuess;
        public bool IsWon => phaseToGuess.AreAllLettersGuessed();
        public bool IsRunning { get; private set; }

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


        public HangmanGame(IRandomWordGenerator randomWordGenerator)
        {
            this.randomWordGenerator = randomWordGenerator;
        }

        public void StartGame()
        {
            string generatedWord = randomWordGenerator.GetRandomWord();
            
            phaseToGuess = new PhaseToGuess(generatedWord);
            Tries = 7;
            IsRunning = true;
        }
        
        public void Guess(char guess) 
        {
            GuessInternal(guess);
        }
        
        public void Guess(string guess) 
        {
            GuessInternal(guess);
        }

        public void GuessPhase(string phase)
        {
            CheckRunningGame();
            
            bool wasGuessSuccessful = phaseToGuess.TryGuessing(phase);
            
            if (!wasGuessSuccessful)
                Tries -= 1;
        }

        public string GetVisiblePhase()
        {
            return phaseToGuess.GetVisiblePhase();
        }

        private void GuessInternal(dynamic guess)
        {
            CheckRunningGame();

            bool wasGuessSuccessful = phaseToGuess.TryGuessing(guess);

            if (!wasGuessSuccessful)
                Tries -= 1;
        }
        
        private void CheckRunningGame()
        {
            if (!IsRunning)
                throw new InvalidOperationException("Cannot play when game is not running.");
        }
    }
}