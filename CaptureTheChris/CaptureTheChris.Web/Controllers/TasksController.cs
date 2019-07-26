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
    public class TasksController : Controller
    {
        private readonly IBirthdayAfterWorkTimeChecker birthdayAfterWorkTimeChecker;
        private readonly ITaskAvailabilityChecker taskAvailabilityChecker;
        
        public TasksController(IBirthdayAfterWorkTimeChecker birthdayAfterWorkTimeChecker, 
            ITaskAvailabilityChecker taskAvailabilityChecker)
        {
            this.birthdayAfterWorkTimeChecker = birthdayAfterWorkTimeChecker;
            this.taskAvailabilityChecker = taskAvailabilityChecker;
        }

        public ActionResult Index()
        {
            var tasksModel = new TasksModel
            {
                IsPastBirthdayAfterWorkTime = birthdayAfterWorkTimeChecker.IsPastBirthdayAfterWorkTime(),
                IsCakeTaskAvailable = taskAvailabilityChecker.IsCakeTaskAvailable(),
                IsCarTaskAvailable = taskAvailabilityChecker.IsCarTaskAvailable(),
                IsMetroTaskAvailable = taskAvailabilityChecker.IsMetroTaskAvailable()
            };

            return View(tasksModel);
        }
    }
}