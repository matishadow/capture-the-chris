using System;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using NodaTime;

namespace CaptureTheChris.Time
{
    public class PolandTimeChecker : IPolandTimeChecker,
        ISingleInstanceDependency, IAsImplementedInterfacesDependency
    {
        private const string PolandZoneId = "Europe/Warsaw";
        public static readonly DateTimeZone PolandZone = DateTimeZoneProviders.Tzdb[PolandZoneId];

        public bool IsPastTime(ZonedDateTime dateTimeToCheck)
        {
            Instant currentInstance = Instant.FromDateTimeUtc(DateTime.UtcNow);
            ZonedDateTime currentDateTime = currentInstance.InZone(PolandZone);
            
            int comparisonResult = ZonedDateTime.Comparer.Local.Compare(currentDateTime, dateTimeToCheck);
            
            return comparisonResult > 0;
        }
    }
}