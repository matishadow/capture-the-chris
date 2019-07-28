using System.Collections.Generic;
using CaptureTheChris.Trivia;

namespace CaptureTheChris.Web.Models
{
    public class TriviaModel : GameModel
    {
        public TriviaModel(bool isWon, string flag, bool wasLastTrySuccessful) : base(isWon, flag, wasLastTrySuccessful)
        {
        }

        public IList<QuestionAnswerResult> QuestionAnswerResults { get; set; }
    }
}