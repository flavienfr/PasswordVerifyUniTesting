using System;
using System.Linq;

namespace Calculator
{
    public class PasswordVerifier
    {
        private const string SpecialCharacters = "$?!";
        private static int CountOccurenceInString(string str, Func<char, bool> func)
        {
            return (str.Count(c => func(c)));
        }

        private static bool IsSpecial(char c)
        {
            if (SpecialCharacters.IndexOf(c) != -1)
                return (true);
            return false;
        }

        public static bool Verify(string password)
        {
            if (password == null)
                return false;
            if (password.Length < 8)
                return (false);
            if (CountOccurenceInString(password, char.IsUpper) < 1)
                return false;
            if (CountOccurenceInString(password, char.IsLower) < 1)
                return false;
            if (CountOccurenceInString(password, char.IsDigit) < 1)
                return false;
            if (CountOccurenceInString(password, IsSpecial) == -1)
                return false;
            return (true);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
