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

        public bool TryGuessingLetter(char guess)
        {
            bool wasGuessingSuccessful =
                lettersToGuess.Any(letterToGuess => !letterToGuess.IsGuessed && letterToGuess.Letter == guess);
            
            if (wasGuessingSuccessful)
                RevealLetters(guess);

            return wasGuessingSuccessful;
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