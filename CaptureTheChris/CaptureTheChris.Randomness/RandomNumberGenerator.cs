using System;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;

namespace CaptureTheChris.Randomness
{
    public class RandomNumberGenerator : IRandomNumberGenerator,
        IInstancePerRequestDependency, IAsImplementedInterfacesDependency 
    {
        private readonly Random random;

        public RandomNumberGenerator()
        {
            random = new Random();
        }

        public int GetRandomInteger(int n)
        {
            return random.Next(n);
        }
    }
}