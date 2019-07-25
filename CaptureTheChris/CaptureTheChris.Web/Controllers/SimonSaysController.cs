using System.Collections.Generic;
using System.Web.Mvc;
using CaptureTheChris.Enums;
using CaptureTheChris.SimonSays;
using CaptureTheChris.Web.Models;

namespace CaptureTheChris.Web.Controllers
{
    public class SimonSaysController : TimeRestrictedController
    {
        private readonly ISimonSaysGame simonSaysGame;

        public SimonSaysController(ISimonSaysGame simonSaysGame)
        {
            this.simonSaysGame = simonSaysGame;
        }

        public ActionResult Index()
        {
            simonSaysGame.StartGame();
            
            var simonSaysResult = new SimonSaysModel(simonSaysGame.IsWon, simonSaysGame.GetFlag(),
                false, simonSaysGame.GetColorsToRemember(), simonSaysGame.RoundNumber);

            return View(simonSaysResult);
        }

        [HttpPost]
        public PartialViewResult Answer(IList<SimonSaysColor> colors)
        {
            simonSaysGame.TurnRound(colors);
            
            var simonSaysResult = new SimonSaysModel(simonSaysGame.IsWon, simonSaysGame.GetFlag(),
                false, simonSaysGame.GetColorsToRemember(), simonSaysGame.RoundNumber);
            
            return PartialView("_SimonSaysGame", simonSaysResult);
        }
    }
}