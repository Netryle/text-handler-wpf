using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandler.Utility
{
    internal class FileWriter
    {
        private string _outputFilePath;
        public FileWriter(string outputFilePath)
        {
            _outputFilePath = outputFilePath;
        }

        private async Task WriteDataAsync(IEnumerable<string> processedDataLines)
        {
            using (StreamWriter writer = new StreamWriter(_outputFilePath))
            {
                foreach (string line in processedDataLines)
                {
                    await writer.WriteLineAsync(line);
                }
            }
        }

    }
}
