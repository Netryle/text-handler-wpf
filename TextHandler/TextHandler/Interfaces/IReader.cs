using System.Collections.Generic;

namespace TextHandler.Interfaces
{
    public interface IReader
    {
        public IAsyncEnumerable<char[]> ReadDataAsync();
    }
}
