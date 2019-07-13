using System.Collections.Generic;

namespace CaptureTheChris.Sudoku
{
    public interface ISudokuGame
    {
        bool IsWon { get; }
        bool IsRunning { get; }
        void StartGame();
        bool TryProvideAnswer(IEnumerable<int> proposedAnswer);
        string GetFlag();
    }
}