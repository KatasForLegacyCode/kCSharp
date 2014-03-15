using NUnit.Framework;

namespace DependencyKata.Tests
{
    [TestFixture]
    public class DoItAllTests
    {
        [Test, Category("Integration")]
        public void DoItAll_Does_ItAll()
        {
            var doItAll = new DoItAll(new FakeConsoleAdapter(), new FakeLogger());

            Assert.DoesNotThrow(() => doItAll.Do());
        }
        [Test, Category("Integration")]
        public void DoItAll_Fails_ToWriteToDB()
        {
            var doItAll = new DoItAll(new FakeConsoleAdapter(), new DatabaseLogger());

            StringAssert.Contains("Database.SaveToLog Exception:", doItAll.Do());
        }
        [Test, Category("Integration")]
        public void DoItAll_Succeeds_WithMockLogging()
        {
            var doItAll = new DoItAll(new FakeConsoleAdapter(), new FakeLogger());

            Assert.AreEqual(string.Empty, doItAll.Do());
        }
    }

    public class FakeConsoleAdapter : IConsoleAdapter
    {
        public string GetInput()
        {
            return "fakeInput";
        }

        public void SetOutput(string output)
        {
        }
    }

    public class FakeLogger : ILogger
    {
        public string LogMessage(string message)
        {
            return string.Empty;
        }
    }
}
