using System.Threading.Tasks;

namespace TextHandler.Interfaces
{
    public interface IWriter
    {
        public Task WriteDataAsync(string processedDataLine);
        public void Close();
    }
}
