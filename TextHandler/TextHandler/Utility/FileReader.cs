using System.Collections.Generic;
using System.IO;
using TextHandler.Interfaces;

namespace TextHandler.Utility
{
    public class FileReader : IReader
    {
        private string _inputFilePath;
        public FileReader(string inputFilePath)
        {
            _inputFilePath = inputFilePath;
        }
        public async IAsyncEnumerable<char[]> ReadDataAsync()
        {
            int bufferSize = 1024 * 4;
            char[] buffer = new char[bufferSize];
            int charsRead;

            using (StreamReader reader = new StreamReader(_inputFilePath))
            {
                while ((charsRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    yield return buffer;
                }
            }
        }
    }
}
