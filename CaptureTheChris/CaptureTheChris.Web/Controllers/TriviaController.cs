using System.Collections.Generic;
using System.Web.Mvc;
using CaptureTheChris.GuessNumber;
using CaptureTheChris.Trivia;
using CaptureTheChris.Web.Models;

namespace CaptureTheChris.Web.Controllers
{
    public class TriviaController : TimeRestrictedController
    {
        private readonly ITriviaGame triviaGame;

        public TriviaController(ITriviaGame triviaGame)
        {
            this.triviaGame = triviaGame;
        }

        public ActionResult Index()
        {
            triviaGame.StartGame();
            
            return View(triviaGame);
        }

        [HttpPost]
        public PartialViewResult Answer(IList<string> answers)
        {
            bool wasLastTrySuccessful = triviaGame.TryAnswer(answers);
            var gameResult = new GameModel(triviaGame.IsWon, triviaGame.GetFlag(), wasLastTrySuccessful);

            return PartialView("_Flag", gameResult);
        }
    }
}