using System.Web.Mvc;
using CaptureTheChris.ProjectEuler;
using CaptureTheChris.Time;
using CaptureTheChris.Web.Attributes;
using CaptureTheChris.Web.Models;

namespace CaptureTheChris.Web.Controllers
{
    public class ProjectEulerController : TimeRestrictedController
    {
        private readonly IProjectEulerGame projectEulerGame;

        public ProjectEulerController(IProjectEulerGame projectEulerGame)
        {
            this.projectEulerGame = projectEulerGame;
        }

        public ActionResult Index()
        {
            return View(projectEulerGame);
        }

        [HttpPost]
        public PartialViewResult Answer(string answer)
        {
            projectEulerGame.StartGame();
            
            bool wasLastTrySuccessful = projectEulerGame.TryProvideAnswer(answer);
            var gameResult = new GameModel(projectEulerGame.IsWon, projectEulerGame.GetFlag(), wasLastTrySuccessful);

            return PartialView("_Flag", gameResult);
        }
    }
}