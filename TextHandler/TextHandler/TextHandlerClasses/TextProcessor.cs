using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextHandler.TextHandlerClasses
{
    public class TextProcessor
    {
        public string InputFilePath { get; private set; }
        public string OutputFilePath { get; private set; }
        public int MinWordLength { get; private set; }
        public Dictionary<string, bool> PunctuationMarks { get; private set; }

        public TextProcessor(
            string inputFilePath, 
            string outputFilePath, 
            int minWordLength, 
            Dictionary<string, bool> punctuationMarks)
        {
            InputFilePath = inputFilePath;
            OutputFilePath = outputFilePath;
            MinWordLength = minWordLength;
            PunctuationMarks = punctuationMarks;
        }

        private IEnumerable<string> SplitTextIntoWordsAndPunctuation(string text)
        {
            return Regex.Split(text, @"\b\w+\b|\W");
        }

        private bool IsWordValid(string word)
        {
            return (!PunctuationMarks.ContainsKey(word) || !PunctuationMarks[word])
                && word.Length >= MinWordLength;
        }

        public string ProcessText(string input)
        {
            var wordsAndPunctuation = SplitTextIntoWordsAndPunctuation(input)
                .Select(word => word.Trim())
                .Where(word => IsWordValid(word));

            return string.Join("", wordsAndPunctuation);
        }
    }
}
