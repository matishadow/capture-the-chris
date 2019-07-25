using System.Collections.Generic;
using CaptureTheChris.Enums;

namespace CaptureTheChris.SimonSays
{
    public interface ISimonSaysGame
    {
        IEnumerable<SimonSaysColor> GetColorsToRemember();
        void TurnRound(IList<SimonSaysColor> colors);
        bool IsWon { get; }
        bool IsRunning { get; }
        void StartGame();
        string GetFlag();
        int RoundNumber { get; }
    }
}