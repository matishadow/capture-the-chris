namespace CaptureTheChris.Web.Models
{
    public class GameResult
    {
        public GameResult(bool isWon, string flag, bool wasLastTrySuccessful)
        {
            IsWon = isWon;
            Flag = flag;
            WasLastTrySuccessful = wasLastTrySuccessful;
        }

        public GameResult()
        {
        }

        public bool IsWon { get; }
        public string Flag { get; }
        public bool? WasLastTrySuccessful { get; }
    }
}