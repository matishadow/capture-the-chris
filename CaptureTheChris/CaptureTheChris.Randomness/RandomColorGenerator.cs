using System;
using CaptureTheChris.Enums;

namespace CaptureTheChris.Randomness
{
    public class RandomColorGenerator : IRandomColorGenerator
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
