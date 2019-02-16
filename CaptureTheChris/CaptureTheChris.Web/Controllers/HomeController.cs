using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptureTheChris.Enums;

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
            return View();
        }

        [HttpPost]
        public ActionResult GeneratePassword()
        {
            return Json(null);
        }
    }
}