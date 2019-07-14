using System.Collections.Generic;
using System.Linq;
using CaptureTheChris.Hangman;

namespace CaptureTheChris.Web.Models
{
    public class HangmanModel : GameModel
    {
        public int Tries { get; }
        public List<char> VisiblePhase { get; }
        
        public HangmanModel(bool isWon, string flag, bool wasLastTrySuccessful, int tries, string visiblePhase) : base(isWon, flag, wasLastTrySuccessful)
        {
            Tries = tries;
            VisiblePhase = new List<char>(visiblePhase);
        }

        public HangmanModel()
        {
            Tries = HangmanGame.StartingNumberOfTries;
            VisiblePhase = new List<char>();
        }
    }
}