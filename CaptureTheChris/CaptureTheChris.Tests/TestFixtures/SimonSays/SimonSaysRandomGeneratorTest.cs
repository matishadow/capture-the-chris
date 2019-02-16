using System;
using CaptureTheChris.Interfaces.SimonSays;
using CaptureTheChris.SimonSays;
using NUnit.Framework;

namespace CaptureTheChris.Tests.TestFixtures.SimonSays
{
    [TestFixture]
    public class SimonSaysRandomGeneratorTest
    {
        private ISimonSaysRandomGenerator randomGenerator;
        
        [SetUp]
        public void SetUp()
        {
            randomGenerator = new SimonSaysRandomGenerator();
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void TestGetRandomNumber(int maxValue)
        {
            int randomNumber = randomGenerator.GetRandomNumber(maxValue);
            Assert.IsTrue(randomNumber < maxValue);
        }
        
        [TestCase(-10)]
        [TestCase(-100)]
        public void TestGetRandomNumberNegative(int maxValue)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => randomGenerator.GetRandomNumber(maxValue));
        }
        
        [TestCase(0, ExpectedResult = 0)]
        public int TestGetRandomNumberZero(int maxValue)
        {
            return randomGenerator.GetRandomNumber(maxValue);
        }
    }
}