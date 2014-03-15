using System;
using System.IO;

namespace DependencyKata
{
    public interface IConsoleAdapter
    {
        string GetInput();
        void SetOutput(string output);
    }

    public class ConsoleAdapter : IConsoleAdapter
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void SetOutput(string output)
        {
            Console.WriteLine(output);
        }
    }

    public class DoItAll
    {
        private const string _passwordsDontMatch = "The passwords don't match.";
        private readonly UserDetails _userDetails = new UserDetails();
        private readonly IConsoleAdapter _consoleAdapter;

        public DoItAll(IConsoleAdapter consoleAdapter)
        {
            _consoleAdapter = consoleAdapter;
        }

        public string Do()
        {
            _consoleAdapter.SetOutput("Enter a username");
            _userDetails.Username = _consoleAdapter.GetInput();
            _consoleAdapter.SetOutput("Enter your full name");
            var fullName = _consoleAdapter.GetInput();
            _consoleAdapter.SetOutput("Enter your password");
            _userDetails.Password = _consoleAdapter.GetInput();
            _consoleAdapter.SetOutput("Re-enter your password");
            var confirmPassword = _consoleAdapter.GetInput();

            if (_userDetails.PasswordEncrypted != new UserDetails{Password = confirmPassword}.PasswordEncrypted)
            {
                _consoleAdapter.SetOutput(_passwordsDontMatch);
                _consoleAdapter.GetInput();
                return _passwordsDontMatch;
            }

            var message = string.Format("Saving Details for User ({0}, {1}, {2})\n", 
                _userDetails.Username, fullName, _userDetails.PasswordEncrypted);

            _consoleAdapter.SetOutput(message);

            try
            {
                Database.SaveToLog(message);
            }
            catch (Exception ex)
            {
                // If database write fails, write to file
                using (var writer = new StreamWriter("log.txt", true))
                {
                    var errorMessage = string.Format("{0} - Database.SaveToLog Exception: \r\n{1}",
                        message, ex.Message);
                    writer.WriteLine(errorMessage);

                    _consoleAdapter.GetInput();
                    return errorMessage;
                }
            }
            _consoleAdapter.GetInput();
            return message;
        }
    }
}
