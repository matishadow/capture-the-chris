namespace CaptureTheChris.Hangman
{
    public interface IPhaseToGuess
    {
        LetterToGuess this[int index] { get; }
        bool AreAllLettersGuessed();
        bool TryGuessingLetter(char guess);
    }
}