using NUnit.Framework;

namespace DependencyKata.Tests
{
    [TestFixture]
    public class DoItAllTests
    {
        [Test, Category("Integration")]
        public void DoItAll_Does_ItAll()
        {
            var doItAll = new DoItAll();
            doItAll.Do();
        }
    }
}
