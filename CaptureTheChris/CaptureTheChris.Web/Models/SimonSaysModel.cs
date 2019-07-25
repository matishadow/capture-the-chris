using System.Collections.Generic;
using CaptureTheChris.Enigma;
using CaptureTheChris.Enums;

namespace CaptureTheChris.Web.Models
{
    public class SimonSaysModel : GameModel
    {
        public SimonSaysModel(bool isWon, string flag, bool wasLastTrySuccessful,
            IEnumerable<SimonSaysColor> colorsToRemember, int roundNumber) : base(isWon, flag, wasLastTrySuccessful)
        {
            ColorsToRemember = colorsToRemember;
            RoundNumber = roundNumber;
        }

        public IEnumerable<SimonSaysColor> ColorsToRemember { get; }
        public int RoundNumber { get; }
    }
}