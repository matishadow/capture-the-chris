using System;
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

        private readonly SortedDictionary<int, QuestionAnswerResult> dictionary =
            new SortedDictionary<int, QuestionAnswerResult>();

        public TriviaGame() : base(Flags.Properties.Resources.FlagTrivia)
        {
            IList<string> answers = LoadFromResources(AnswerResourceKey);
            IList<string> questions = LoadFromResources(QuestionResourceKey);

            for (var i = 0; i < answers.Count; i++)
            {
                dictionary.Add(i, new QuestionAnswerResult
                {
                    Answer = answers[i],
                    Question = questions[i]
                });
            }
        }

        public override bool IsWon { get; protected set; }
        public override bool IsRunning { get; protected set; }

        public IList<string> Questions
        {
            get { return dictionary.Values.Select(value => value.Question).ToList(); }
        }

        public override void StartGame()
        {
            IsRunning = true;
            IsWon = false;
        }

        public bool TryAnswer(IList<string> answers)
        {
            var resourceAnswers = dictionary.Values.Select(value => value.Answer).ToList();
                
            if (answers.Count != resourceAnswers.Count) return false;
            answers = answers.Select(a => a.ToLower()).ToList();

            if (answers.Where((answer, i) => !answer.Contains(resourceAnswers[i])).Any())
                return false;

            IsRunning = false;
            IsWon = true;

            return true;
        }

        public bool TryAnswer(IList<string> answers, out IList<QuestionResult> questionResults)
        {
            var result = new List<QuestionResult>();

            for (int i = 0; i < dictionary.Count; i++)
            {
                var wasAnswerValid = answers[i] != string.Empty
                    ? answers[i].ToLower().Contains(dictionary[i].Answer)
                    : (bool?) null;
                
                result.Add(new QuestionResult
                {
                    Question = dictionary[i].Question,
                    Result = wasAnswerValid
                });
            }

            questionResults = result;
            return TryAnswer(answers);
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