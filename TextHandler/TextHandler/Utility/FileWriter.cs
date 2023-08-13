using System.IO;
using System.Threading.Tasks;
using TextHandler.Interfaces;

namespace TextHandler.Utility
{
    public class FileWriter : IWriter
    {
        private string _outputFilePath;
        private StreamWriter _writer;
        public FileWriter(string outputFilePath)
        {
            _outputFilePath = outputFilePath;
            _writer = new StreamWriter(_outputFilePath);
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
