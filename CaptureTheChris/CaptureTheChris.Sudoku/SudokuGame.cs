using System.Collections.Generic;
using System.Linq;
using CaptureTheChris.Flags.Properties;
using CaptureTheChris.GameLogic;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;

namespace CaptureTheChris.Sudoku
{
    public class SudokuGame : Game, IGame, ISudokuGame,
        ISingleInstanceDependency, IAsImplementedInterfacesDependency
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

        public readonly int?[][] VisibleNumbers =
        {
            new int?[]{null, null, null, 7, null, 4, null, null, 5},
            new int?[]{null, 2, null, null, 1, null, null, 7, null},
            new int?[]{null, null, null, null, 8, null, null, null, 2},
            new int?[]{null, 9, null, null, null, 6, 2, 5, null},
            new int?[]{6, null, null, null, 7, null, null, null, 8},
            new int?[]{null, 5, 3, 2, null, null, null, 1, null},
            new int?[]{4, null, null, null, 9, null, null, null, null},
            new int?[]{null, 3, null, null, 6, null, null, 9, null},
            new int?[]{2, null, null, 4, null, 7, null, null, null}
        };

        public SudokuGame() : base(Resources.FlagSudoku)
        {
        }

        public override bool IsWon { get; protected set; }
        public override bool IsRunning { get; protected set; }

        public override void StartGame()
        {
            IsWon = false;
            IsRunning = true;
        }

        public bool TryProvideAnswer(IEnumerable<int> proposedAnswer)
        {
            CheckRunningGame();

            if (!proposedAnswer.SequenceEqual(answer)) return false;

            IsRunning = false;
            IsWon = true;

            return true;
        }
    }
}