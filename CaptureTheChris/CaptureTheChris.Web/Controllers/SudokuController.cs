using System.Collections.Generic;
using System.Web.Mvc;
using CaptureTheChris.Sudoku;
using CaptureTheChris.Web.Models;

namespace CaptureTheChris.Web.Controllers
{
    public class SudokuController : TimeRestrictedController
    {
        private readonly ISudokuGame sudokuGame;

        public SudokuController(ISudokuGame sudokuGame)
        {
            this.sudokuGame = sudokuGame;
        }

        public ActionResult Index()
        {
            return View(sudokuGame);
        }

        [HttpPost]
        public PartialViewResult Answer(IEnumerable<int> answer)
        {
            sudokuGame.StartGame();
            
            bool wasLastTrySuccessful = sudokuGame.TryProvideAnswer(answer);
            var gameResult = new GameModel(sudokuGame.IsWon, sudokuGame.GetFlag(), wasLastTrySuccessful);

            return PartialView("_Flag", gameResult);
        }
    }
}