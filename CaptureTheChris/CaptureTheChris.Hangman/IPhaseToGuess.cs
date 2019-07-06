namespace CaptureTheChris.Hangman
{
    public interface IPhaseToGuess
    {
        LetterToGuess this[int index] { get; }
        bool AreAllLettersGuessed();
        bool TryGuessing(char guess);
        bool TryGuessing(string guess);
        string GetVisiblePhase();
    }
}