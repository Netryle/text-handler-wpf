using TextHandler.Models;
using TextHandler.Tests.Mocks;

namespace TextHandler.Tests
{
    [TestFixture]
    public class MainModelTests
    {
        private MainModel _mainModel;
        private int _minWordLength;
        private Dictionary<char, bool> _punctuationMarks;
        private FileReaderMock _fileReader;
        private FileWriterMock _fileWriter;

        [SetUp]
        public void Setup() 
        {
            _mainModel = new MainModel();
            _minWordLength = 3;
            _punctuationMarks = new Dictionary<char, bool>()
            {
                {'.', true },
                {',', false },
                {'!', true },
            };
            _fileReader = new FileReaderMock("input.txt");
            _fileWriter = new FileWriterMock("output.txt");
        }

        async Task ExecuteHandleTextFile() => await _mainModel.HandleTextFile(
                _minWordLength,
                _punctuationMarks,
                _fileReader,
                _fileWriter);

        [Test]
        public async Task HandleTextFile_ShouldProcessTextWithoutExceptions()
        {
            Assert.DoesNotThrowAsync(ExecuteHandleTextFile);
        }

        [Test]
        public async Task HandleTextFile_MethodCallCountVerification()
        {
            ExecuteHandleTextFile();

            Assert.AreEqual(1, _fileReader.GetCallCount);
            Assert.AreEqual(3, _fileWriter.GetCallCount);
        }
    }
}
