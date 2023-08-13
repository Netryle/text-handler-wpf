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
        private StreamWriter _writer;
        public FileWriter(string outputFilePath)
        {
            _outputFilePath = outputFilePath;
            _writer = new StreamWriter(outputFilePath);
        }

        public async Task WriteDataAsync(string processedDataLine)
        {
            await _writer.WriteLineAsync(processedDataLine);
        }

        public void Close()
        {
            _writer.Close();
        }

    }
}
