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
    public class SimonSaysGameTest
    {
        private ISimonSaysGame simonSaysGame;

        private readonly SimonSaysColor[] notSoRandomColors = 
        {
            SimonSaysColor.Blue, SimonSaysColor.Green, SimonSaysColor.Red, SimonSaysColor.Yellow, SimonSaysColor.Blue,
            SimonSaysColor.Green, SimonSaysColor.Red, SimonSaysColor.Yellow, SimonSaysColor.Blue, SimonSaysColor.Green
        };

        [SetUp]
        public void Setup()
        {
            var simonSaysColorGeneratorMock = new Mock<ISimonSaysColorGenerator>();
            simonSaysColorGeneratorMock.SetupSequence(s => s.GetRandomColor())
                .Returns(notSoRandomColors[0])
                .Returns(notSoRandomColors[1])
                .Returns(notSoRandomColors[2])
                .Returns(notSoRandomColors[3])
                .Returns(notSoRandomColors[4])
                .Returns(notSoRandomColors[5])
                .Returns(notSoRandomColors[6])
                .Returns(notSoRandomColors[7])
                .Returns(notSoRandomColors[8])
                .Returns(notSoRandomColors[9]);
            
            this.simonSaysGame = new SimonSaysGame(simonSaysColorGeneratorMock.Object);
        }

        [Test]
        public void TestStopGameWithoutStart()
        {
            Assert.Throws<InvalidOperationException>(() => simonSaysGame.StopGame());
        }
        
        [Test]
        public void TestStopGameWithStartedGame()
        {
            simonSaysGame.StartGame(5);
            Assert.True(simonSaysGame.StopGame());
        }

        [Test]
        public void TestStartGameWithStartedGame()
        {
            simonSaysGame.StartGame(5);
            Assert.Throws<InvalidOperationException>(() => simonSaysGame.StartGame(5));
        }

        [Test]
        public void TestStartGameWithNotStartedGame()
        {
            Assert.True(simonSaysGame.StartGame(5));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        public void TestSuccessGame(int numberOfRounds)
        {
            simonSaysGame.StartGame(numberOfRounds);

            
            for (var i = 0; i < numberOfRounds; i++)
            {
                IList<SimonSaysColor> colors = simonSaysGame.GetColorsToRemember().ToList();
                Assert.AreEqual(colors[i], notSoRandomColors[i]);

                bool turnResult = simonSaysGame.TurnRound(colors);
                Assert.True(turnResult);
            }
        }

        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(0)]
        public void TestStartGameInvalidArgument(int numberOfRounds)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => simonSaysGame.StartGame(numberOfRounds));
        }

        [Test]
        public void TestTurnRoundWithoutStart()
        {
            Assert.Throws<InvalidOperationException>(() => simonSaysGame.TurnRound(new List<SimonSaysColor>()));
        }
        
        [Test]
        public void TestGetColorsToRememberWithoutStart()
        {
            Assert.Throws<InvalidOperationException>(() => simonSaysGame.GetColorsToRemember());
        }
        
        [Test]
        public void TestTurnRoundWithMoreColors()
        {
            const int numberOfRounds = 1;
            
            simonSaysGame.StartGame(numberOfRounds);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                simonSaysGame.TurnRound(new List<SimonSaysColor> {SimonSaysColor.Blue, SimonSaysColor.Blue}));
        }

        [TestCase(SimonSaysColor.Blue, SimonSaysColor.Green, SimonSaysColor.Red, SimonSaysColor.Blue)]
        [TestCase(SimonSaysColor.Blue, SimonSaysColor.Green, SimonSaysColor.Blue)]
        [TestCase(SimonSaysColor.Blue, SimonSaysColor.Blue, SimonSaysColor.Blue, SimonSaysColor.Blue,
            SimonSaysColor.Blue)]
        [TestCase(SimonSaysColor.Blue, SimonSaysColor.Green, SimonSaysColor.Red, SimonSaysColor.Yellow,
            SimonSaysColor.Blue,
            SimonSaysColor.Green, SimonSaysColor.Red, SimonSaysColor.Yellow, SimonSaysColor.Blue, SimonSaysColor.Blue)]
        public void TestFailGame(params SimonSaysColor[] colors)
        {
            simonSaysGame.StartGame(colors.Length);

            bool gameResult = colors.Select((t, i) => colors.Take(i + 1)).Aggregate(true,
                (current, takenColors) => current && simonSaysGame.TurnRound(takenColors.ToList()));

            Assert.False(gameResult);
        }

        [Test]
        public void TestTurnRoundNull()
        {
            simonSaysGame.StartGame(5);

            Assert.Throws<ArgumentNullException>(() => simonSaysGame.TurnRound(null));
        }
    }
}