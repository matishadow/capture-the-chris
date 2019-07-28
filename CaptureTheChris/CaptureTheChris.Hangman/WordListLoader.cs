using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaptureTheChris.Hangman.Properties;
using CaptureTheChris.Interfaces.Dependencies.RegistrationRelated;
using CaptureTheChris.Interfaces.Dependencies.ScopeRelated;

namespace CaptureTheChris.Hangman
{
    public class WordListLoader : IWordListLoader,
        ISingleInstanceDependency, IAsImplementedInterfacesDependency
    {
        public WordListLoader()
        {
            LoadWordListFromResources();
        }

        public IList<string> WordList { get; private set; }

        private void LoadWordListFromResources()
        {
            string asOneString = Resources.some_words;

            WordList = asOneString.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
        }
    }
}
