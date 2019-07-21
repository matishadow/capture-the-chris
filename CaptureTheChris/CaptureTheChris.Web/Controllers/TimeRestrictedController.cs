using System.Web.Mvc;
using CaptureTheChris.Web.Attributes;

namespace CaptureTheChris.Web.Controllers
{
    [TimeFilter]
    public abstract class TimeRestrictedController : Controller
    {
        
    }
}