using System.Collections.Generic;
using CaptureTheChris.Enigma;

namespace CaptureTheChris.Web.Models
{
    public class EnigmaModel : GameModel
    {
        public EnigmaModel(bool isWon, string flag, bool wasLastTrySuccessful, int triesCount,
            IList<EnigmaGuessResult> tries) : base(isWon, flag, wasLastTrySuccessful)
        {
            TriesCount = triesCount;
            Tries = tries;
        }

        public int TriesCount { get; }
        public IList<EnigmaGuessResult> Tries { get; }
    }
}