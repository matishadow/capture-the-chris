using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using CaptureTheChris.Randomness;

namespace CaptureTheChris.Hangman
{
    public class RandomWordGenerator : IRandomWordGenerator,
        ISingleInstanceDependency, IAsImplementedInterfacesDependency
    {
        private readonly IRandomNumberGenerator randomNumberGenerator;
        private readonly IWordListLoader wordListLoader;

        public RandomWordGenerator(IRandomNumberGenerator randomNumberGenerator, IWordListLoader wordListLoader)
        {
            this.randomNumberGenerator = randomNumberGenerator;
            this.wordListLoader = wordListLoader;
        }

        public string GetRandomWord()
        {
            int wordCount = wordListLoader.WordList.Count;

            int randomWordPosition = randomNumberGenerator.GetRandomInteger(wordCount);

            return wordListLoader.WordList[randomWordPosition];
        }
    }
}