using System;
using CaptureTheChris.Enums;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;

namespace CaptureTheChris.Randomness
{
    public class RandomColorGenerator : IRandomColorGenerator,
        IAsImplementedInterfacesDependency, ISingleInstanceDependency
    {
        private readonly IRandomNumberGenerator randomGenerator;

        public RandomColorGenerator(IRandomNumberGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public TColor GetRandomColor<TColor>() where TColor : Enum
        {
            int numberOfPossibleColors = Enum.GetNames(typeof(TColor)).Length;
            
            int randomNumber = randomGenerator.GetRandomInteger(numberOfPossibleColors);
            return (TColor) Enum.ToObject(typeof(TColor), randomNumber);
        }
    }
}
