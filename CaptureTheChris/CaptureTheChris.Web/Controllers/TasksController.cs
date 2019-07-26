using System;
using System.Linq;
using System.Web.Mvc;
using CaptureTheChris.Enigma;
using CaptureTheChris.Enums;
using CaptureTheChris.Hangman;
using CaptureTheChris.Time;
using CaptureTheChris.Web.Models;

namespace CaptureTheChris.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly IBirthdayAfterWorkTimeChecker birthdayAfterWorkTimeChecker;
        
        public TasksController(IBirthdayAfterWorkTimeChecker birthdayAfterWorkTimeChecker)
        {
            this.birthdayAfterWorkTimeChecker = birthdayAfterWorkTimeChecker;
        }

        public ActionResult Index()
        {
            bool isAfterWork = birthdayAfterWorkTimeChecker.IsPastBirthdayAfterWorkTime();

            var tasksModel = new TasksModel
            {
                IsPastBirthdayAfterWorkTime = isAfterWork
            };

            return View(tasksModel);
        }
    }
}