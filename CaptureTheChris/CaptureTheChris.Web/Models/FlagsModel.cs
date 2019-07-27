namespace CaptureTheChris.Web.Models
{
    public class FlagsModel
    {
        public bool? WasLastSubmitSuccessful { get; set; }
        public int CurrentFlagCount { get; set; }
        public int TotalFlagCount { get; set; }
    }
}