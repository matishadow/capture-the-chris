using System;
using System.Linq;
using System.Web.Mvc;
using CaptureTheChris.Enigma;
using CaptureTheChris.Enums;
using CaptureTheChris.Flags;
using CaptureTheChris.Hangman;
using CaptureTheChris.Time;
using CaptureTheChris.Web.Models;

namespace CaptureTheChris.Web.Controllers
{
    public class FlagsDetailsController : Controller
    {
        private readonly IFlagChecker flagChecker;
        
        public FlagsDetailsController(IFlagChecker flagChecker)
        {
            this.flagChecker = flagChecker;
        }

        public ActionResult Index()
        {
            var flagsDetailsModel = new FlagsDetailsModel(flagChecker.GetAllFlagStatuses());
            
            return View(flagsDetailsModel);
        }
    }
}