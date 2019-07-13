using System;
using CaptureTheChris.GameLogic;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;

namespace CaptureTheChris.ProjectEuler
{
    public class ProjectEulerGame : Game, IProjectEulerGame,
        ISingleInstanceDependency, IAsImplementedInterfacesDependency
    {
        public ProjectEulerGame() : base(Flags.Properties.Resources.FlagProjectEuler)
        {
        }

        public override bool IsWon { get; protected set; }
        public override bool IsRunning { get; protected set; }
        public override void StartGame()
        {
            IsWon = false;
            IsRunning = true;
        }

        public bool TryProvideAnswer(string answer)
        {
            CheckRunningGame();

            answer = answer.Replace(',', '.').ToLower().Substring(0, Math.Min(7, answer.Length));
            
            if (answer != "pi/12" && answer != "π/12" && answer != "0.26180" && answer != "0.26179") return false;
            
            IsRunning = false;
            IsWon = true;

            return true;
        }
    }
}