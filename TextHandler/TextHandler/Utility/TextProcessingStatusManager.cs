using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandler.Utility
{
    class TextProcessingStatusManager
    {
        string _inputFilePath;
        string _outputFilePath;
        public TextProcessingStatusManager(
            string inputFilePath, 
            string outputFilePath) 
        { 
            _inputFilePath = inputFilePath;
            _outputFilePath = outputFilePath;
        }

        public string GetStatusText(bool status)
        {
            var result =
                $"{_inputFilePath}\n" +
                $"===>\n" +
                $"{_outputFilePath}\n" +
                $"Status: {(status ? "Сompleted":"Not Completed")}\n\n";

            return result;
        }
    }
}
