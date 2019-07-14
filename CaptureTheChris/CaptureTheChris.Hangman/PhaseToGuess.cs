using System;
using System.Collections.Generic;
using System.Linq;

namespace CaptureTheChris.Hangman
{
    public class PhaseToGuess : IPhaseToGuess
    {
        private readonly IList<LetterToGuess> lettersToGuess = new List<LetterToGuess>();

        public PhaseToGuess(string phase)
        {
            phase.ToList().ForEach(letter => lettersToGuess.Add(new LetterToGuess(letter)));
        }

        public LetterToGuess this[int index] => lettersToGuess[index];

        public bool AreAllLettersGuessed()
        {
            return lettersToGuess.All(letter => letter.IsGuessed);
        }

        public bool TryGuessing(char guess)
        {
            bool wasGuessingSuccessful =
                lettersToGuess.Any(letterToGuess => !letterToGuess.IsGuessed && letterToGuess.Letter == guess);

            if (wasGuessingSuccessful)
                RevealLetters(guess);

            return wasGuessingSuccessful;
        }

        public bool TryGuessing(string guess)
        {
            bool isGuessedWhole = guess == GetWholePhase();

            if (!isGuessedWhole) return false;
            
            foreach (char letter in guess)
                RevealLetters(letter);

            return true;
        }

        public string GetVisiblePhase()
        {
            return new string(lettersToGuess
                .Select(letterToGuess => letterToGuess.IsGuessed ? letterToGuess.Letter : '_')
                .ToArray());
        }

        private string GetWholePhase()
        {
            return new string(lettersToGuess.Select(letterToGuess => letterToGuess.Letter).ToArray());
        }

        private void RevealLetters(char guessedLetter)
        {
            foreach (var letterToGuess in lettersToGuess)
            {
                letterToGuess.TryGuessing(guessedLetter);
            }
        }
    }
}