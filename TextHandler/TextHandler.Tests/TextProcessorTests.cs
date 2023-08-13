using TextHandler.TextHandlerClasses;
namespace TextHandler.Tests
{
    [TestFixture]
    public class TextProcessorTests
    {
        private TextProcessor _textProcessor;

        [SetUp]
        public void Setup()
        {
            int minWordLength = 3;
            Dictionary<char, bool> punctuationMarks = new Dictionary<char, bool>()
        {
            {'.', true },
            {',', false },
            {'!', false },
            {'\"', true }
        };
            _textProcessor = new TextProcessor(minWordLength, punctuationMarks);
        }

        [Test]
        public void ProcessText_ShouldDeleteWordsLessThanGivenLength()
        {
            char[] input = "Apple an and so wow".ToCharArray();
            string expected = "Apple and wow";

            string result = _textProcessor.ProcessText(input) 
                + _textProcessor.Flush();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProcessText_ShouldProcessPunctuation()
        {
            char[] input = "\"Remember,\" the old man said.".ToCharArray();
            string expected = "Remember, the old man said";

            string result = _textProcessor.ProcessText(input) 
                + _textProcessor.Flush();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProcessText_ShouldNotRemovePunctuationThatIsNotInDictionary()
        {
            char[] input = "///,;;.;.;!.!?".ToCharArray();
            string expected = "///,;;;;!!?";

            string result = _textProcessor.ProcessText(input) 
                + _textProcessor.Flush();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProcessText_ShouldProcessWhitespace()
        {
            char[] input = "Hello\nworld !".ToCharArray();
            string expected = "Hello\nworld !";

            string result = _textProcessor.ProcessText(input) 
                + _textProcessor.Flush();

            Assert.AreEqual(expected, result);
        }
    }

}