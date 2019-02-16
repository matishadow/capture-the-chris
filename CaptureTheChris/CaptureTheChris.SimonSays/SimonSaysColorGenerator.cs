using System;
using CaptureTheChris.Enums;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using CaptureTheChris.Interfaces.SimonSays;

namespace CaptureTheChris.SimonSays
{
    public class SimonSaysColorGenerator : ISimonSaysColorGenerator,
        IAsImplementedInterfacesDependency, IInstancePerRequestDependency
    {
        private readonly int numberOfPossibleColors = Enum.GetNames(typeof(SimonSaysColor)).Length;
        private readonly ISimonSaysRandomGenerator randomGenerator;

        public SimonSaysColorGenerator(ISimonSaysRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public SimonSaysColor GetRandomColor()
        {
            int randomNumber = randomGenerator.GetRandomNumber(numberOfPossibleColors);
            return (SimonSaysColor) randomNumber;
        }
    }
}