using NUnit.Framework;

namespace DependencyKata.Tests
{
    [TestFixture]
    public class DoItAllTests
    {
        [Test, Category("Integration")]
        public void DoItAll_Does_ItAll()
        {
            var doItAll = new DoItAll(new FakeConsoleAdapter());

            Assert.DoesNotThrow(() => doItAll.Do());
        }
        [Test, Category("Integration")]
        public void DoItAll_Fails_ToWriteToDB()
        {
            var doItAll = new DoItAll(new FakeConsoleAdapter());

            StringAssert.Contains("Database.SaveToLog Exception:", doItAll.Do());
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
}
