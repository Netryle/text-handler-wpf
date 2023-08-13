using TextHandler.Interfaces;

namespace TextHandler.Tests.Mocks
{
    internal class FileWriterMock : IWriter
    {
        private uint _callCount = 0;

        public uint GetCallCount { get { return _callCount; } }
        public async Task WriteDataAsync(string processedDataLine)
        {
            _callCount++;
            await Task.CompletedTask;
        }
        public FileWriterMock(string outputFilePath) { }

        public void Close()
        {

        }
    }
}
