using NUnit.Framework;
using FastTracker.Models;

namespace FastTracker.Tests
{
    public class FileParserTest
    {
        FileParser fileparser = new FileParser("skibidi");

        [Test]
        public void TestFileParserConstructor()
        {
            Assert.Equals("skibidi", fileparser.filename);
        }
    }
}
