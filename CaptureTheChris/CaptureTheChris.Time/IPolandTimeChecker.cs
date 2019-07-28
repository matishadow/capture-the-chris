using NodaTime;

namespace CaptureTheChris.Time
{
    public interface IPolandTimeChecker
    {
        bool IsPastTime(ZonedDateTime zonedDateTime);
    }
}