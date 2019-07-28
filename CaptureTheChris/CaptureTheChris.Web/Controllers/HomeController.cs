using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptureTheChris.Enums;
using CaptureTheChris.Flags;

namespace CaptureTheChris.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var flagChecker = new FlagChecker();
            flagChecker.SubmitFlag("CTC{fajny_siusiak}");
            
            return View();
        }

        [HttpPost]
        public ActionResult GeneratePassword()
        {
            return Json(null);
        }
    }
}