using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using NodaTime;

namespace CaptureTheChris.Time
{
    public class BirthdayAfterWorkTimeChecker : IBirthdayAfterWorkTimeChecker,
        ISingleInstanceDependency, IAsImplementedInterfacesDependency
    {
        private readonly IBirthdayAfterWorkTime birthdayAfterWorkTime;
        private readonly IPolandTimeChecker polandTimeChecker;

        public BirthdayAfterWorkTimeChecker(IBirthdayAfterWorkTime birthdayAfterWorkTime, IPolandTimeChecker polandTimeChecker)
        {
            this.birthdayAfterWorkTime = birthdayAfterWorkTime;
            this.polandTimeChecker = polandTimeChecker;
        }

        public bool IsPastBirthdayAfterWorkTime()
        {
            ZonedDateTime afterWorkTime = birthdayAfterWorkTime.GetDateTime();

            bool isPastTime = polandTimeChecker.IsPastTime(afterWorkTime);

            return isPastTime;
        }
    }
}