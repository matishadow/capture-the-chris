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
            Settings.Default.IsFoosballWon = flag == Resources.FlagFoosball;
            Settings.Default.IsGerritWon = flag == Resources.FlagGerrit;
            Settings.Default.IsOrigamiWon = flag == Resources.FlagOrigami;
            Settings.Default.IsCaveWon = flag == Resources.FlagCave;
            
            Settings.Default.IsCarWon = flag == Resources.FlagCar;
            Settings.Default.IsMetroWon = flag == Resources.FlagMetro;
            Settings.Default.IsCakeWon = flag == Resources.FlagCake;

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