namespace CaptureTheChris.Hangman
{
    public class LetterToGuess
    {
        public LetterToGuess(char letter)
        {
            Letter = letter;
            IsGuessed = false;
        }

        public void TryGuessing(char letter)
        {
            if (letter == Letter)
                IsGuessed = true;
        }

        public bool IsGuessed { get; private set; }

        public char Letter { get; }
    }
}