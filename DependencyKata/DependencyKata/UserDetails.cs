using System;

namespace DependencyKata
{
    public class UserDetails
    {
        private string _passwordEncrypted;
        private string _password;
        private string _username;
        private string _fullname;

        public string Password
        {
            set
            {
                if (value.Length < 8)
                {
                    Console.WriteLine("Password must be at least 8 characters in length. You fail.");
                }
                else
                {
                    _password = value;
                }
            }
        }

        public string PasswordEncrypted
        {
            get
            {
                // Encrypt the password (just reverse it, should be secure)
                var array = _password.ToCharArray();
                Array.Reverse(array);
                _passwordEncrypted = new string(array);
                return _passwordEncrypted;
            }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Fullname
        {
            get { return _fullname; }
            set { _fullname = value; }
        }
    }
}