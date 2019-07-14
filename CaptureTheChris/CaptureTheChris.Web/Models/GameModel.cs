namespace CaptureTheChris.Web.Models
{
    public class GameModel
    {
        public GameModel(bool isWon, string flag, bool wasLastTrySuccessful)
        {
            IsWon = isWon;
            Flag = flag;
            WasLastTrySuccessful = wasLastTrySuccessful;
        }

        public GameModel()
        {
        }

        public bool IsWon { get; }
        public string Flag { get; }
        public bool? WasLastTrySuccessful { get; }
    }
}