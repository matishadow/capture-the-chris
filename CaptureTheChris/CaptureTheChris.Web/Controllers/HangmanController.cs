using System.Linq;
using System.Web.Mvc;
using CaptureTheChris.Hangman;
using CaptureTheChris.Web.Models;

namespace CaptureTheChris.Web.Controllers
{
    public class HangmanController : TimeRestrictedController
    {
        private readonly IHangmanGame hangmanGame;

        public HangmanController(IHangmanGame hangmanGame)
        {
            this.hangmanGame = hangmanGame;
        }

        public ActionResult Index()
        {
            hangmanGame.StartGame();

            var hangmanResult = new HangmanModel(hangmanGame.IsWon, hangmanGame.GetFlag(),
                false, hangmanGame.Tries, hangmanGame.GetVisiblePhase());

            return View(hangmanResult);
        }

        [HttpPost]
        public PartialViewResult Answer(string answer)
        {
            answer = answer.ToUpper();
            
            bool wasLastTrySuccessful =
                answer.Length == 1 ? hangmanGame.TryGuess(answer.First()) : hangmanGame.TryGuess(answer);
            
            var hangmanResult = new HangmanModel(hangmanGame.IsWon, hangmanGame.GetFlag(), wasLastTrySuccessful,
                hangmanGame.Tries, hangmanGame.GetVisiblePhase());
            
            return PartialView("_HangmanGame", hangmanResult);
        }
    }
}