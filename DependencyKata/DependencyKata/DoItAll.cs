using System;
using System.IO;

namespace DependencyKata
{
    public class DoItAll
    {
        private readonly UserDetails _userDetails = new UserDetails();

        public void Do()
        {
            Console.WriteLine("Enter a username");
            _userDetails.Username = Console.ReadLine();
            Console.WriteLine("Enter your full name");
            var fullName = Console.ReadLine();
            Console.WriteLine("Enter your password");
            _userDetails.Password = Console.ReadLine();
            Console.WriteLine("Re-enter your password");
            var confirmPassword = Console.ReadLine();

            if (_userDetails.PasswordEncrypted != new UserDetails{Password = confirmPassword}.PasswordEncrypted)
            {
                Console.WriteLine("The passwords don't match.");
                Console.ReadKey();
                return;
            }

            var message = string.Format("Saving Details for User ({0}, {1}, {2})\n", 
                _userDetails.Username, fullName, _userDetails.PasswordEncrypted);

            Console.Write(message);

            try
            {
                Database.SaveToLog(message);
            }
            catch (Exception ex)
            {
                // If database write fails, write to file
                using (var writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine("{0} - Database.SaveToLog Exception: \r\n{1}", 
                        message, ex.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
