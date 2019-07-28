using System;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using NodaTime;
using NodaTime.Extensions;
using NodaTime.Text;

namespace CaptureTheChris.Time
{
    public class BirthdayAfterWorkTime : IBirthdayAfterWorkTime,
        ISingleInstanceDependency, IAsImplementedInterfacesDependency
    {
        public ZonedDateTime GetDateTime()
        {
            LocalDateTime localDateTime = new DateTime(2019, 7, 29, 15, 30, 0).ToLocalDateTime();
            
            ZonedDateTime zonedDateTime = localDateTime.InZoneLeniently(PolandTimeChecker.PolandZone);

            return zonedDateTime;
        }
    }
}