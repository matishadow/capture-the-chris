using System.Web.Mvc;
using CaptureTheChris.ProjectEuler;

namespace CaptureTheChris.Web.Controllers
{
    public class ProjectEulerController : Controller
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
        public ActionResult Answer(string answer)
        {
            projectEulerGame.StartGame();
            
            projectEulerGame.ProvideAnswer(answer);

            return View("Index", projectEulerGame);
        }
    }
}