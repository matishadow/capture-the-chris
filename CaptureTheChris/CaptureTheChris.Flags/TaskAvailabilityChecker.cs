using CaptureTheChris.Flags.Properties;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;

namespace CaptureTheChris.Flags
{
    public class TaskAvailabilityChecker : ITaskAvailabilityChecker,
        ISingleInstanceDependency, IAsImplementedInterfacesDependency
    {
        public bool AreOutsideTaskAvailable()
        {
            return Settings.Default.IsEnigmaWon &&
                   Settings.Default.IsHangmanWon &&
                   Settings.Default.IsSudokuWon &&
                   Settings.Default.IsTriviaWon &&
                   Settings.Default.IsGuessNumberWon &&
                   Settings.Default.IsProjectEulerWon &&
                   Settings.Default.IsSimonSaysWon &&
                   Settings.Default.IsFoosballWon &&
                   Settings.Default.IsGerritWon &&
                   Settings.Default.IsOrigamiWon &&
                   Settings.Default.IsCaveWon;
        }

        public bool IsCarTaskAvailable()
        {
            return AreOutsideTaskAvailable();
        }

        public bool IsMetroTaskAvailable()
        {
            return AreOutsideTaskAvailable() && Settings.Default.IsCarWon;
        }
        
        public bool IsCakeTaskAvailable()
        {
            return AreOutsideTaskAvailable() && Settings.Default.IsMetroWon;
        }
    }
}