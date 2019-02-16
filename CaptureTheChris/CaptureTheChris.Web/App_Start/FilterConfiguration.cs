using System.Web;
using System.Web.Mvc;

namespace CaptureTheChris.Web
{
    internal static class FilterConfiguration
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
