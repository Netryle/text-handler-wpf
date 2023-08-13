using TextHandler.Interfaces;

namespace TextHandler.Tests.Mocks
{
    internal class FileReaderMock : IReader
    {
        private List<char[]> charsList = new List<char[]>()
        {
            "Some long text!".ToCharArray(),
            "Some, long.. text?!".ToCharArray(),
            "Some, long.. text333...?!".ToCharArray()
        };
        private uint _callCount = 0;

        public uint GetCallCount { get { return _callCount; } }

        public async IAsyncEnumerable<char[]> ReadDataAsync()
        {
            _callCount++;
            foreach (char[] chars in charsList)
            {
                yield return chars;
            }
        }
        public FileReaderMock(string inputFilePath) { }

    }
}
