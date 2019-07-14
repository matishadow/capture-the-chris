using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using CaptureTheChris.GameLogic;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;
using Resources = CaptureTheChris.Trivia.Properties.Resources;

namespace CaptureTheChris.Trivia
{
    public class TriviaGame : Game, IGame, 
        ISingleInstanceDependency, IAsImplementedInterfacesDependency, ITriviaGame
    {
        private const string AnswerResourceKey = "Answer";
        private const string QuestionResourceKey = "Question";

        private readonly IList<string> resourceAnswers;

        public TriviaGame() : base(Flags.Properties.Resources.FlagTrivia)
        {
            resourceAnswers = LoadFromResources(AnswerResourceKey);
            Questions = LoadFromResources(QuestionResourceKey);
        }

        public override bool IsWon { get; protected set; }
        public override bool IsRunning { get; protected set; }
        
        public IList<string> Questions { get; }

        public override void StartGame()
        {
            IsRunning = true;
            IsWon = false;
        }

        public bool TryAnswer(IList<string> answers)
        {
            if (answers.Count != resourceAnswers.Count) return false;

            if (answers.Where((answer, i) => answer != resourceAnswers[i]).Any())
                return false;

            IsRunning = false;
            IsWon = true;

            return true;
        }

        private IList<string> LoadFromResources(string thingToLoad)
        {
            var answersDictionary = new SortedDictionary<int, string>();
            ResourceSet resourceSet = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
            
            foreach (DictionaryEntry entry in resourceSet)
            {
                string key = entry.Key.ToString();

                if (!key.Contains(thingToLoad)) continue;
                if (key.Length <= thingToLoad.Length) continue;
                if (!int.TryParse(key.Substring(thingToLoad.Length), out int dictionaryKey)) continue;
                
                answersDictionary.Add(dictionaryKey, entry.Value.ToString());
            }

            return answersDictionary.Values.ToList();
        }
    }
}