using System.Web.Mvc;
using CaptureTheChris.GuessNumber;
using CaptureTheChris.Web.Models;

namespace CaptureTheChris.Web.Controllers
{
    public class GuessNumberController : Controller
    {
        private readonly IGuessNumberGame guessNumberGame;

        public GuessNumberController(IGuessNumberGame guessNumberGame)
        {
            this.guessNumberGame = guessNumberGame;
        }

        public ActionResult Index()
        {
            guessNumberGame.StartGame();
            
            return View(guessNumberGame);
        }

        [HttpPost]
        public PartialViewResult Answer(int answer)
        {
            bool wasLastTrySuccessful = guessNumberGame.TryGuess(answer);
            var gameResult = new GameModel(guessNumberGame.IsWon, guessNumberGame.GetFlag(), wasLastTrySuccessful);

            return PartialView("_Flag", gameResult);
        }
    }
}