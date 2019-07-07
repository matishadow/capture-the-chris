using System.Collections.Generic;
using System.Linq;
using CaptureTheChris.GameLogic;

namespace CaptureTheChris.Sudoku
{
    public class SudokuGame : Game, IGame
    {
        private readonly IEnumerable<int> answer = new[]
        {
            9, 8, 1, 7, 2, 4, 3, 6, 5,
            3, 2, 4, 6, 1, 5, 8, 7, 9,
            7, 6, 5, 9, 8, 3, 1, 4, 2,
            1, 9, 7, 8, 3, 6, 2, 5, 4,
            6, 4, 2, 5, 7, 1, 9, 3, 8,
            8, 5, 3, 2, 4, 9, 7, 1, 6,
            4, 7, 6, 3, 9, 8, 5, 2, 1,
            5, 3, 8, 1, 6, 2, 4, 9, 7,
            2, 1, 9, 4, 5, 7, 6, 8, 3
        };

        public SudokuGame() : base(Flags.Properties.Resources.FlagSudoku)
        {
        }

        public override bool IsWon { get; protected set; }
        public override bool IsRunning { get; protected set; }

        public override void StartGame()
        {
            IsWon = false;
            IsRunning = true;
        }

        public void ProvideAnswer(IEnumerable<int> proposedAnswer)
        {
            CheckRunningGame();

            if (!proposedAnswer.SequenceEqual(answer)) return;

            IsRunning = false;
            IsWon = true;
        }
    }
}