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
    public class FlagsController : Controller
    {
        private readonly IFlagChecker flagChecker;
        
        public FlagsController(IFlagChecker flagChecker)
        {
            this.flagChecker = flagChecker;
        }

        public ActionResult Index()
        {
            var flagsModel = new FlagsModel
            {
                CurrentFlagCount = flagChecker.GetCurrentFlagsCount(),
                TotalFlagCount = flagChecker.GetTotalFlagCount
            };
            
            return View(flagsModel);
        }
        
        [HttpPost]
        public PartialViewResult SubmitFlag(string flag)
        {
            flag = flag
                .Replace("\n", "")
                .Replace("\r", "")
                .Replace("\\n", "")
                .ToUpper();

            bool wasLastTrySuccessful = flagChecker.SubmitFlag(flag); 
            
            var flagsModel = new FlagsModel
            {
                WasLastSubmitSuccessful = wasLastTrySuccessful,
                CurrentFlagCount = flagChecker.GetCurrentFlagsCount(),
                TotalFlagCount = flagChecker.GetTotalFlagCount
            };
            
            return PartialView("_Flags", flagsModel);
        }
    }
}