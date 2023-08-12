using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandler.Utility
{
    internal class FileReader
    {
        private string _inputFilePath;
        public FileReader(string inputFilePath)
        {
            _inputFilePath = inputFilePath;
        }
        public async IAsyncEnumerable<string> ReadDataAsync()
        {
            int bufferSize = 1024 * 4;
            char[] buffer = new char[bufferSize];
            int charsRead;

            using (StreamReader reader = new StreamReader(_inputFilePath))
            {
                while ((charsRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    yield return new string(buffer, 0, charsRead);
                }
            }
        }
    }
}
