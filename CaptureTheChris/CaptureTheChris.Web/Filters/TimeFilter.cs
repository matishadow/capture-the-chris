using System.Web.Mvc;
using CaptureTheChris.Time;

namespace CaptureTheChris.Web.Attributes
{
    public class TimeFilter : ActionFilterAttribute
    {
        public IBirthdayAfterWorkTimeChecker birthdayAfterWorkTimeChecker { get; set; }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
#if DEBUG
#else
            if (!birthdayAfterWorkTimeChecker.IsPastBirthdayAfterWorkTime())
            {
                filterContext.Result = new EmptyResult();
            }
#endif
        }
    }
}