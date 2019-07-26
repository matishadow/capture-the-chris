using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using LiteDB;

namespace CaptureTheChris.Flags
{
    using Properties;

    public class FlagChecker
    {
        public bool SubmitFlag(string flag)
        {
            if (!IsSubmissionValid(flag))
                return false;
            
            using(var db = new LiteDatabase("C:\\home\\site\\wwwroot\\Flags.config"))
            {
                var flags = db.GetCollection<Flags>(nameof(Flags));

                Flags savedFlags = flags.FindOne(f => true) ?? new Flags();

                savedFlags.IsEnigmaWon = flag == Resources.FlagEnigma;
                savedFlags.IsHangmanWon = flag == Resources.FlagHangman;
                savedFlags.IsSudokuWon = flag == Resources.FlagSudoku;
                savedFlags.IsTriviaWon = flag == Resources.FlagTrivia;
                savedFlags.IsGuessNumberWon = flag == Resources.FlagGuessNumber;
                savedFlags.IsProjectEulerWon = flag == Resources.FlagProjectEuler;
                savedFlags.IsSimonSaysWon = flag == Resources.FlagSimonSays;
                savedFlags.IsFoosballWon = flag == Resources.FlagFoosball;
                savedFlags.IsGerritWon = flag == Resources.FlagGerrit;
                savedFlags.IsOrigamiWon = flag == Resources.FlagOrigami;
                savedFlags.IsCaveWon = flag == Resources.FlagCave;
                
                savedFlags.IsCarWon = flag == Resources.FlagCar;
                savedFlags.IsMetroWon = flag == Resources.FlagMetro;
                savedFlags.IsCakeWon = flag == Resources.FlagCake;

                flags.Delete(f => true);
                flags.Insert(savedFlags);
            }
            
            return true;
        }

        private static bool IsSubmissionValid(string flag)
        {
            foreach (DictionaryEntry resource in Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                if ((string) resource.Value == flag)
                    return true;
            }

            return false;
        }
    }
}