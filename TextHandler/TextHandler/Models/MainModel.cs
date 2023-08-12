using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextHandler.Utility;
using System.Threading.Tasks;
using TextHandler.TextHandlerClasses;

namespace TextHandler.Models
{
    internal class MainModel
    {
        public async Task HandleTextFile(
            string inputFilePath, 
            string outputFilePath, 
            int minWordLength, 
            Dictionary<string, bool> punctuationMarks)
        {
            var textProcessor = new TextProcessor(inputFilePath, outputFilePath, minWordLength, punctuationMarks);
            await textProcessor.Handle();
        }

        public TextProcessingStatusManager GetStatusManager(
            string inputFilePath,
            string outputFilePath)
        {
            return new TextProcessingStatusManager(inputFilePath, outputFilePath);
        }
    }
}
