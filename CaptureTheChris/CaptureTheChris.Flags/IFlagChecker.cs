namespace CaptureTheChris.Flags
{
    public interface IFlagChecker
    {
        bool SubmitFlag(string flag);
        int GetCurrentFlagsCount();
        int GetTotalFlagCount { get; }
        Flags GetAllFlagStatuses();
    }
}