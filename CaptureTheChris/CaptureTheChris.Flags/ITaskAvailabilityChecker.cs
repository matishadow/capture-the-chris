namespace CaptureTheChris.Flags
{
    public interface ITaskAvailabilityChecker
    {
        bool AreOutsideTaskAvailable();
        bool IsCarTaskAvailable();
        bool IsMetroTaskAvailable();
        bool IsCakeTaskAvailable();
    }
}