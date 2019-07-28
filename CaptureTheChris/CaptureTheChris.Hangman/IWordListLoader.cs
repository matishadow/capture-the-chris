using System.Collections.Generic;

namespace CaptureTheChris.Hangman
{
    public interface IWordListLoader
    {
        IList<string> WordList { get; }
    }
}