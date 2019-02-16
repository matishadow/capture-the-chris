using System.Linq;
using NUnit.Framework;

namespace CaptureTheChris.Tests.TestFixtures
{
    [TestFixture]
    public class ExampleTest
    {
        private int[] someArray;
        
        [SetUp]
        public void SetUp()
        {
            someArray = new[] {1, 2, 3};
        }

        [Test]
        public void TestLengthEqualToThree()
        {
            Assert.AreEqual(someArray.Length, 3);
        }

        [TestCase(1, 2, 3, ExpectedResult = 6)]
        [TestCase(2, -2, ExpectedResult = 0)]
        [TestCase(2, 2, 2, ExpectedResult = 6)]
        public int TestAddingWorks(params int[] elements)
        {
            return elements.Sum();
        }
    }
}