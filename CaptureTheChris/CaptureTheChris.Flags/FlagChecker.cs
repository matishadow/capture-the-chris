using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using LiteDB;

namespace CaptureTheChris.Flags
{
    using Properties;

    public class FlagChecker : 
        IAsImplementedInterfacesDependency, ISingleInstanceDependency, IFlagChecker
    {
        public bool SubmitFlag(string flag)
        {
            if (!IsSubmissionValid(flag))
                return false;
            
            using(var db = new LiteDatabase(Resources.FlagsPath))
            {
                var flags = db.GetCollection<Flags>(nameof(Flags));

                Flags savedFlags = flags.FindOne(f => true) ?? new Flags();

                if (flag == Resources.FlagEnigma) savedFlags.IsEnigmaWon = true;
                if (flag == Resources.FlagHangman) savedFlags.IsHangmanWon = true;
                if (flag == Resources.FlagSudoku) savedFlags.IsSudokuWon = true;
                if (flag == Resources.FlagTrivia) savedFlags.IsTriviaWon = true;
                if (flag == Resources.FlagGuessNumber) savedFlags.IsGuessNumberWon = true;
                if (flag == Resources.FlagProjectEuler) savedFlags.IsProjectEulerWon = true;
                if (flag == Resources.FlagSimonSays) savedFlags.IsSimonSaysWon = true;
                if (flag == Resources.FlagFoosball) savedFlags.IsFoosballWon = true;
                if (flag == Resources.FlagGerrit) savedFlags.IsGerritWon = true;
                if (flag == Resources.FlagOrigami) savedFlags.IsOrigamiWon = true;
                if (flag == Resources.FlagCave) savedFlags.IsCaveWon = true;
                
                if (flag == Resources.FlagCar) savedFlags.IsCarWon = true;
                if (flag == Resources.FlagMetro) savedFlags.IsMetroWon = true;
                if (flag == Resources.FlagCake) savedFlags.IsCakeWon = true;

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

        public int GetCurrentFlagsCount()
        {
            var currentFlagCount = 0;
            
            using(var db = new LiteDatabase(Resources.FlagsPath))
            {
                var flags = db.GetCollection<Flags>(nameof(Flags));

                Flags savedFlags = flags.FindOne(f => true) ?? new Flags();

                var properties = typeof(Flags).GetProperties();
                currentFlagCount +=
                    (from property in properties
                        let value = property.GetValue(savedFlags)
                        where property.PropertyType == typeof(bool) && property.Name.Contains("Won")
                        select (bool) value).Count(isWon => isWon);
            }

            return currentFlagCount;
        }
        
        public int GetTotalFlagCount => 14;

        public Flags GetAllFlagStatuses()
        {
            using (var db = new LiteDatabase(Resources.FlagsPath))
            {
                var flags = db.GetCollection<Flags>(nameof(Flags));

                Flags savedFlags = flags.FindOne(f => true) ?? new Flags();

                return savedFlags;
            }
        }
    }
}