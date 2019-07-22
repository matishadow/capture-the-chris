using System.Collections.Generic;
using CaptureTheChris.Enums;

namespace CaptureTheChris.Enigma
{
    public interface IEnigmaGame
    {
        bool IsWon { get; }
        bool IsRunning { get; }
        IList<EnigmaGuessResult> Tries { get; }
        int CurrentNumberOfTries { get; }
        void StartGame();
        EnigmaGuessResult GuessColors(EnigmaColor[] colors);
        string GetFlag();
    }
}