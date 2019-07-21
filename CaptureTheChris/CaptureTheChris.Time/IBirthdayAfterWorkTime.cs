using NodaTime;

namespace CaptureTheChris.Time
{
    public interface IBirthdayAfterWorkTime
    {
        ZonedDateTime GetDateTime();
    }
}