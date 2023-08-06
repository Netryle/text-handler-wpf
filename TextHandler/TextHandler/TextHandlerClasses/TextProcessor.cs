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

        public string CreateNewStringWithSetParams(List<string> words, int minWordLength)
        {
            var filteredWords = words
                .Select(word => word.Trim())
                .Where(word => (PunctuationMarks.ContainsKey(word) 
                    && !PunctuationMarks[word])
                    || word.Length >= minWordLength)
                .ToList();

            return string.Join(" ", filteredWords);
        }

        public async Task Handle()
        {
            List<string> wordsAndPunctuation;
            string tempLine;

            using (StreamReader reader = new StreamReader(InputFilePath))
            using (StreamWriter writer = new StreamWriter(OutputFilePath))
            {
                while ((tempLine = await reader.ReadLineAsync()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(tempLine))
                    {
                        var matches = Regex.Matches(tempLine, @"\b\w+\b|\W");
                        wordsAndPunctuation = matches.Cast<Match>().Select(match => match.Value).ToList();
                        var newString = CreateNewStringWithSetParams(wordsAndPunctuation, MinWordLength);

                        if (newString != "")
                        {
                            await writer.WriteLineAsync(newString);
                        }
                    }
                }
            }
        }
    }
}
