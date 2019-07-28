using CaptureTheChris.Flags.Properties;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using LiteDB;

namespace CaptureTheChris.Flags
{
    public class TaskAvailabilityChecker : ITaskAvailabilityChecker,
        ISingleInstanceDependency, IAsImplementedInterfacesDependency
    {
        public bool AreOutsideTaskAvailable()
        {
            using(var db = new LiteDatabase(Resources.FlagsPath))
            {
                var flags = db.GetCollection<Flags>(nameof(Flags));

                Flags savedFlags = flags.FindOne(f => true) ?? new Flags();

                return savedFlags.IsEnigmaWon &&
                       savedFlags.IsHangmanWon &&
                       savedFlags.IsSudokuWon &&
                       savedFlags.IsTriviaWon &&
                       savedFlags.IsGuessNumberWon &&
                       savedFlags.IsProjectEulerWon &&
                       savedFlags.IsSimonSaysWon &&
                       savedFlags.IsFoosballWon &&
                       savedFlags.IsGerritWon &&
                       savedFlags.IsOrigamiWon &&
                       savedFlags.IsCaveWon;
            }
        }

        public bool IsCarTaskAvailable()
        {
            return AreOutsideTaskAvailable();
        }

        public bool IsMetroTaskAvailable()
        {
            using(var db = new LiteDatabase(Resources.FlagsPath))
            {
                var flags = db.GetCollection<Flags>(nameof(Flags));

                Flags savedFlags = flags.FindOne(f => true) ?? new Flags();

                return AreOutsideTaskAvailable() && savedFlags.IsCarWon;
            }
        }
        
        public bool IsCakeTaskAvailable()
        {
            using(var db = new LiteDatabase(Resources.FlagsPath))
            {
                var flags = db.GetCollection<Flags>(nameof(Flags));

                Flags savedFlags = flags.FindOne(f => true) ?? new Flags();

                return AreOutsideTaskAvailable() && savedFlags.IsMetroWon;
            }
        }
    }
}