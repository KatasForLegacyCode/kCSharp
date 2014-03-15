namespace DependencyKata.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var doItAll = new DoItAll(new ConsoleAdapter());

            doItAll.Do();
        }
    }
}
