//using TextHandler.TextHandlerClasses;
//namespace TextHandler.Tests
//{
//    [TestFixture]
//    public class TextProcessorTests
//    {
//        [SetUp]
//        public void Setup(){}

//        [Test]
//        public void CreateNewStringWithSetParams_RemovesWordsLessThanMinLength()
//        {
//            ushort minWordLength = 3;
//            TextProcessor textProcessor = new TextProcessor("", "", minWordLength, new Dictionary<string, bool>());
//            List<string> words = new List<string> { "as", "test", "a", "good", "boy" };
//            int expectedCount = 3;

//            string result = textProcessor.CreateNewStringWithSetParams(words, minWordLength);

//            Assert.AreEqual(expectedCount, result.Split(' ').Length);
//        }

//        [Test]
//        public void CreateNewStringWithSetParams_RemovesPunctuationMarks()
//        {
//            ushort minWordLength = 3;
//            TextProcessor textProcessor = new TextProcessor("", "", minWordLength, new Dictionary<string, bool>
//            {
//                { ".", true },
//                { ",", true },
//                { "!", true },
//                { "?", true }
//            });
//            List<string> words = new List<string> { "who", "?", "hello", ".", ",", "world", "!" };
//            int expectedCount = 3;

//            string result = textProcessor.CreateNewStringWithSetParams(words, minWordLength);

//            Assert.AreEqual(expectedCount, result.Split(' ').Length);
//        }

//        [Test]
//        public void CreateNewStringWithSetParams_RemovesEmptyLines()
//        {
//            ushort minWordLength = 3;
//            TextProcessor textProcessor = new TextProcessor("", "", minWordLength, new Dictionary<string, bool>());
//            List<string> words = new List<string> { "\n", "some", "", "text", "\n", "a", "reader", "window", "" };
//            int expectedCount = 4;

//            string result = textProcessor.CreateNewStringWithSetParams(words, minWordLength);

//            Assert.AreEqual(expectedCount, result.Split(' ').Length);
//        }

//        [Test]
//        public void Handle_WritesProcessedTextToFile()
//        {
//            string inputFilePath = "input.txt";
//            string outputFilePath = "output.txt";
//            int minWordLength = 3;
//            Dictionary<string, bool> punctuationMarks = new Dictionary<string, bool> { { ",", true }, { ".", true }, { ":", true } };

//            using (var writer = new System.IO.StreamWriter(inputFilePath))
//            {
//                writer.WriteLine("hello, bye");
//                writer.WriteLine("a nice coat.");
//            }

//            TextProcessor textProcessor = new TextProcessor(inputFilePath, outputFilePath, minWordLength, punctuationMarks);

//            textProcessor.Handle().Wait();

//            Assert.IsTrue(System.IO.File.Exists(outputFilePath));
//            string[] outputLines = System.IO.File.ReadAllLines(outputFilePath);
//            Assert.AreEqual(2, outputLines.Length);
//            Assert.AreEqual("hello bye", outputLines[0]);
//            Assert.AreEqual("nice coat", outputLines[1]);

//            System.IO.File.Delete(inputFilePath);
//            System.IO.File.Delete(outputFilePath);
//        }

//        [Test]
//        public void Constructor_CreatesObjectWithCorrectInitialValues()
//        {
//            string inputFilePath = "input.txt";
//            string outputFilePath = "output.txt";
//            int minWordLength = 3;
//            Dictionary<string, bool> punctuationMarks = new Dictionary<string, bool> { { ",", true }, { ".", true }, { ":", true } };

//            TextProcessor textProcessor = new TextProcessor(inputFilePath, outputFilePath, minWordLength, punctuationMarks);

//            Assert.AreEqual(inputFilePath, textProcessor.InputFilePath);
//            Assert.AreEqual(outputFilePath, textProcessor.OutputFilePath);
//            Assert.AreEqual(minWordLength, textProcessor.MinWordLength);
//            Assert.AreEqual(punctuationMarks, textProcessor.PunctuationMarks);
//        }
//    }
//}