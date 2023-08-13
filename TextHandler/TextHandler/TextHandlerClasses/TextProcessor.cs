using System.Collections.Generic;
using System.Text;

namespace TextHandler.TextHandlerClasses
{
    public class TextProcessor
    {
        private StringBuilder currentWord = new StringBuilder();
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
                    else if (!char.IsWhiteSpace(tempChar))
                    {
                        if (currentWord.Length >= MinWordLength)
                        {
                            result.Append(currentWord);
                            currentWord.Clear();
                        }
                    }
                }
                else if (char.IsLetter(tempChar) 
                    || char.IsDigit(tempChar))
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
                    else
                    {
                        result.Append(tempChar);
                    }

                    currentWord.Clear();
                }
                else if (tempChar == '\0')
                {
                    if (currentWord.Length >= MinWordLength)
                    {
                        result.Append(currentWord);
                        return result.ToString();
                    }
                }
            }

            return result.ToString();
        }

        public string Flush()
        {
            if (currentWord.Length >= MinWordLength)
            {
                return currentWord.ToString();
            }

            return "";
        }
    }
}
