using System;
using CaptureTheChris.Enums;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using CaptureTheChris.Interfaces.SimonSays;
using CaptureTheChris.Randomness;

namespace CaptureTheChris.SimonSays
{
    public class SimonSaysColorGenerator : ISimonSaysColorGenerator,
        IAsImplementedInterfacesDependency, IInstancePerRequestDependency
    {
        private readonly int numberOfPossibleColors = Enum.GetNames(typeof(SimonSaysColor)).Length;
        private readonly IRandomNumberGenerator randomGenerator;

        public SimonSaysColorGenerator(IRandomNumberGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public SimonSaysColor GetRandomColor()
        {
            int randomNumber = randomGenerator.GetRandomInteger(numberOfPossibleColors);
            return (SimonSaysColor) randomNumber;
        }
    }
}