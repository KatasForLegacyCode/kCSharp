namespace DependencyKata.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var doItAll = new DoItAll(new ConsoleAdapter(), new DatabaseLogger());

            doItAll.Do();
        }
    }
}
