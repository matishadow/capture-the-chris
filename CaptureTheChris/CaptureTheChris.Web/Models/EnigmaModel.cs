using System.Collections.Generic;
using CaptureTheChris.Enigma;

namespace CaptureTheChris.Web.Models
{
    public class EnigmaModel : GameModel
    {
        public int TriesCount { get; set; }
        public IList<EnigmaGuessResult> Tries { get; set; }
    }
}