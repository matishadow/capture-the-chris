using System.Collections.Generic;
using CaptureTheChris.Enums;

namespace CaptureTheChris.Interfaces.SimonSays
{
    public interface ISimonSaysGame
    {
        bool StartGame(int numberOfRounds);
        bool StopGame();
        IEnumerable<SimonSaysColor> GetColorsToRemember();
        bool TurnRound(IList<SimonSaysColor> colors);
    }
}