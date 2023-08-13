using System.Collections.Generic;
using TextHandler.Utility;
using System.Threading.Tasks;
using TextHandler.TextHandlerClasses;
using TextHandler.Interfaces;

namespace TextHandler.Models
{
    public class MainModel
    {
        public async Task HandleTextFile(
            int minWordLength, 
            Dictionary<char, bool> punctuationMarks,
            IReader _fileReader,
            IWriter _fileWriter)
        {
            var textProcessor = new TextProcessor(minWordLength, punctuationMarks);

            await foreach (var data in _fileReader.ReadDataAsync())
            {
                var newString = textProcessor.ProcessText(data);
                await _fileWriter.WriteDataAsync(newString);
            }
            await _fileWriter.WriteDataAsync(textProcessor.Flush());
            _fileWriter.Close();
        }

        public TextProcessingStatusManager GetStatusManager(
            string inputFilePath,
            string outputFilePath)
        {
            return new TextProcessingStatusManager(inputFilePath, outputFilePath);
        }
    }
}
