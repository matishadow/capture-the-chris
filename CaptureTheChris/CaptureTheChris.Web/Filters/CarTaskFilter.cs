using System.Web.Mvc;
using CaptureTheChris.Flags;
using CaptureTheChris.Time;

namespace CaptureTheChris.Web.Attributes
{
    public class CarTaskFilter : ActionFilterAttribute
    {
        public ITaskAvailabilityChecker TaskAvailabilityChecker { get; set; }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
#if DEBUG
#else
            if (!TaskAvailabilityChecker.IsCarTaskAvailable())
            {
                filterContext.Result = new EmptyResult();
            }
#endif
        }
    }
}