using System;
using System.Linq;
using System.Web.Mvc;
using CaptureTheChris.Enigma;
using CaptureTheChris.Enums;
using CaptureTheChris.Hangman;
using CaptureTheChris.Time;
using CaptureTheChris.Web.Attributes;
using CaptureTheChris.Web.Models;

namespace CaptureTheChris.Web.Controllers
{
    public class GerritController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}