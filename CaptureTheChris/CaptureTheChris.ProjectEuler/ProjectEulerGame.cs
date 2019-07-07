using System.Collections;
using System.Collections.Generic;
using CaptureTheChris.GameLogic;

namespace CaptureTheChris.ProjectEuler
{
    public class ProjectEulerGame : Game, IGame
    {
        public ProjectEulerGame(string flag) : base(flag)
        {
        }

        public override bool IsWon { get; protected set; }
        public override bool IsRunning { get; protected set; }
        public override void StartGame()
        {
            IsWon = false;
            IsRunning = true;
        }

        public void ProvideAnswer(string answer)
        {
            CheckRunningGame();
            
            answer = answer.Replace(',', '.').ToLower().Substring(0, 7);
            
            if (answer != "pi/12" && answer != "π/12" && answer != "0.26180" && answer != "0.26179") return;
            
            IsRunning = false;
            IsWon = true;
        }
    }
}