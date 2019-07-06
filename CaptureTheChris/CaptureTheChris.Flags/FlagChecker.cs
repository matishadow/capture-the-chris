using System.Globalization;

namespace CaptureTheChris.Flags
{
    using Properties;

    public class FlagChecker
    {
        public bool SubmitFlag(string flag)
        {
            if (!IsSubmissionValid(flag))
                return false;
            
            Settings.Default.IsEnigmaWon = flag == Resources.FlagEnigma;
            Settings.Default.IsHangmanWon = flag == Resources.FlagHangman;
            Settings.Default.IsSudokuWon = flag == Resources.FlagSudoku;
            Settings.Default.IsTriviaWon = flag == Resources.FlagTrivia;
            Settings.Default.IsGuessNumberWon = flag == Resources.FlagGuessNumber;
            Settings.Default.IsProjectEulerWon = flag == Resources.FlagProjectEuler;
            Settings.Default.IsSimonSaysWon = flag == Resources.FlagSimonSays;
            Settings.Default.IsKeyOnPendriveWon = flag == Resources.FlagKeyOnPendrive;
            Settings.Default.IsOneFromMagdaWon = flag == Resources.FlagOneFromMagda;
            Settings.Default.IsOneFromPaperWon = flag == Resources.FlagOneFromPaper;
            
            Settings.Default.Save();
            return true;
        }

        private static bool IsSubmissionValid(string flag)
        {
            foreach (var resource in Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, false, false))
            {
                if (resource as string == flag)
                    return true;
            }

            return false;
        }
    }
}