using System;
using System.Collections.Generic;
using System.Linq;
using CaptureTheChris.Enums;
using CaptureTheChris.Interfaces.SimonSays;
using CaptureTheChris.SimonSays;
using Moq;
using NUnit.Framework;

namespace CaptureTheChris.Tests.TestFixtures.SimonSays
{
    [TestFixture]
    public class SimonSaysColorGeneratorTest
    {
        private readonly ISimonSaysColorGenerator colorGenerator;
        
        public SimonSaysColorGeneratorTest()
        {
            var randomGeneratorMock = new Mock<ISimonSaysRandomGenerator>();
            randomGeneratorMock
                .SetupSequence(r => r.GetRandomNumber(4))
                .Returns(0)
                .Returns(1)
                .Returns(2)
                .Returns(3);
            
            colorGenerator = new SimonSaysColorGenerator(randomGeneratorMock.Object);
        }

        [TestCase(ExpectedResult = (SimonSaysColor)0)]
        [TestCase(ExpectedResult = (SimonSaysColor)1)]
        [TestCase(ExpectedResult = (SimonSaysColor)2)]
        [TestCase(ExpectedResult = (SimonSaysColor)3)]
        public SimonSaysColor TestGetRandomNumberInRange()
        {
            SimonSaysColor returnedColor = colorGenerator.GetRandomColor();
            return returnedColor;
        }
    }
}