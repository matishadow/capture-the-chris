using System.Web.Mvc;
using CaptureTheChris.Flags;
using CaptureTheChris.Time;

namespace CaptureTheChris.Web.Attributes
{
    public class MetroTaskFilter : ActionFilterAttribute
    {
        public ITaskAvailabilityChecker TaskAvailabilityChecker { get; set; }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
#if DEBUG
#else
            if (!TaskAvailabilityChecker.IsMetroTaskAvailable())
            {
                filterContext.Result = new EmptyResult();
            }
#endif
        }
    }
}