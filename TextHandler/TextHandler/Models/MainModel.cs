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
            Dictionary<char, bool> punctuationMarks)
        {
            var textProcessor = new TextProcessor(minWordLength, punctuationMarks);
            var fileReader = new FileReader(inputFilePath);
            var fileWriter = new FileWriter(outputFilePath);

            await foreach (var data in fileReader.ReadDataAsync())
            {
                var newString = textProcessor.ProcessText(data);
                await fileWriter.WriteDataAsync(newString);
            }
            fileWriter.Close();
        }

        public TextProcessingStatusManager GetStatusManager(
            string inputFilePath,
            string outputFilePath)
        {
            return new TextProcessingStatusManager(inputFilePath, outputFilePath);
        }
    }
}
