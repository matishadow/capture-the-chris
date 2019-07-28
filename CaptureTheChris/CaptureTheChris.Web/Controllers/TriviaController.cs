using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CaptureTheChris.GuessNumber;
using CaptureTheChris.Trivia;
using CaptureTheChris.Web.Models;

namespace CaptureTheChris.Web.Controllers
{
    public class TriviaController : TimeRestrictedController
    {
        private readonly ITriviaGame triviaGame;

        public TriviaController(ITriviaGame triviaGame)
        {
            this.triviaGame = triviaGame;
        }

        public ActionResult Index()
        {
            triviaGame.StartGame();

            var questionAnswerResults = triviaGame.Questions
                .Select(question => new QuestionAnswerResult {Question = question})
                .ToList();

            var triviaModel = new TriviaModel(triviaGame.IsWon, triviaGame.GetFlag(), false)
            {
                QuestionAnswerResults = questionAnswerResults
            };
            
            return View(triviaModel);
        }

        [HttpPost]
        public PartialViewResult Answer(IList<string> answers)
        {
            IList<QuestionResult> questionResults;

            bool wasLastTrySuccessful = triviaGame.TryAnswer(answers, out questionResults);
            
            var triviaModel = new TriviaModel(triviaGame.IsWon, triviaGame.GetFlag(), wasLastTrySuccessful);
            IList<QuestionAnswerResult> questionAnswerResults = questionResults.Select((t, i) =>
                new QuestionAnswerResult {Answer = answers[i], Question = t.Question, Result = t.Result}).ToList();
            triviaModel.QuestionAnswerResults = questionAnswerResults;

            return PartialView("_TriviaGame", triviaModel);
        }
    }
}