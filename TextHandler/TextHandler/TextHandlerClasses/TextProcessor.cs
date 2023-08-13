using System.Collections.Generic;
using System.Text;

namespace TextHandler.TextHandlerClasses
{
    public class TextProcessor
    {
        public int MinWordLength { get; private set; }
        public Dictionary<char, bool> PunctuationMarks { get; private set; }

        public TextProcessor(int minWordLength, Dictionary<char, bool> punctuationMarks)
        {
            MinWordLength = minWordLength;
            PunctuationMarks = punctuationMarks;
        }

        public string ProcessText(char[] text)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder currentWord = new StringBuilder();

            foreach (var tempChar in text)
            {
                if (char.IsPunctuation(tempChar))
                {
                    if ((PunctuationMarks.TryGetValue(tempChar, out bool value)
                        && !value)
                        || !PunctuationMarks.ContainsKey(tempChar))
                    {
                        if (currentWord.Length >= MinWordLength)
                        {
                            result.Append(currentWord);
                        }
                        result.Append(tempChar);

                        currentWord.Clear();
                    }
                }
                else if (char.IsLetter(tempChar))
                {
                    currentWord.Append(tempChar);
                }
                else if (char.IsWhiteSpace(tempChar) 
                    || tempChar == '\n' 
                    || tempChar == '\r')
                {
                    if(currentWord.Length >= MinWordLength) 
                    {
                        currentWord.Append(tempChar);
                        result.Append(currentWord);
                    }

                    currentWord.Clear();
                }
            }

            return result.ToString();
        }
    }
}
