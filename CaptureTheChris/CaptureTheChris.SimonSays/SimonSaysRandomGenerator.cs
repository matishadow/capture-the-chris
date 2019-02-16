using System;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using CaptureTheChris.Interfaces.SimonSays;

namespace CaptureTheChris.SimonSays
{
    public class SimonSaysRandomGenerator : ISimonSaysRandomGenerator, 
        IAsImplementedInterfacesDependency, IInstancePerRequestDependency
    {
        private readonly Random random;

        public SimonSaysRandomGenerator()
        {
            random = new Random();
        }

        public int GetRandomNumber(int maxValue)
        {
            return random.Next(maxValue);
        }
    }
}