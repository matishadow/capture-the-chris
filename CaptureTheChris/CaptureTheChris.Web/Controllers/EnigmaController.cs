using System.Linq;
using System.Web.Mvc;
using CaptureTheChris.Enigma;
using CaptureTheChris.Enums;
using CaptureTheChris.Hangman;
using CaptureTheChris.Web.Models;

namespace CaptureTheChris.Web.Controllers
{
    public class EnigmaController : TimeRestrictedController
    {
        private readonly IEnigmaGame enigmaGame;

        public EnigmaController(IEnigmaGame enigmaGame)
        {
            this.enigmaGame = enigmaGame;
        }

        public ActionResult Index()
        {
            enigmaGame.StartGame();
            
            var enigmaResult = new EnigmaModel
            {
                TriesCount = enigmaGame.CurrentNumberOfTries,
                Tries = enigmaGame.Tries
            };

            return View(enigmaResult);
        }

        [HttpPost]
        public PartialViewResult Answer(EnigmaColor[] answer)
        {
            enigmaGame.GuessColors(answer);
            
            var enigmaResult = new EnigmaModel
            {
                TriesCount = enigmaGame.CurrentNumberOfTries,
                Tries = enigmaGame.Tries
            };

            return PartialView("_EnigmaGame", enigmaResult);
        }
    }
}