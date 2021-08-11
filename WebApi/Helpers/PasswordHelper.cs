using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public static class PasswordHelper
    {
        private const string LOWER_CASE = "abcdefghijklmnopqrstuvwxyz";
        private const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string GenerateRandomPassword(int min = 15)
        {
            const string NUMBERS = "0123456789";
            const string SPECIALS = @"~!@#$%^&*():;[]{}<>,.?/|_";

            string allowed = "";
            allowed += LOWER_CASE;
            allowed += UPPER_CASE;
            allowed += NUMBERS;
            allowed += SPECIALS;

            var pwd = "";
            do
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(LOWER_CASE[new Random().Next(LOWER_CASE.Length - 1)]);
                sb.Append(UPPER_CASE[new Random().Next(UPPER_CASE.Length - 1)]);
                sb.Append(NUMBERS[new Random().Next(NUMBERS.Length - 1)]);
                sb.Append(SPECIALS[new Random().Next(SPECIALS.Length - 1)]);

                while (sb.Length < min)
                    sb.Append(allowed[new Random().Next(allowed.Length - 1)]);

                var rnd = new Random();
                pwd = string.Join(string.Empty, sb.ToString().OrderBy(x => rnd.Next()).ToList());
            }
            while (!PasswordIsValid(pwd));
            return pwd;
        }

        public static bool PasswordIsValid(string password)
        {
            password = password.Trim();

            if (password.Length < 15)
                return false;

            for (var i = 0; i < password.Length - 1; i++)
            {
                if (password[i] == password[i + 1])
                    return false;
            }

            if (!password.Any(char.IsNumber))
                return false;

            if (!password.Any(char.IsUpper))
                return false;

            if (!password.Any(char.IsLower))
                return false;

            if (Regex.IsMatch(password, "^[a-zA-Z0-9\x20]+$"))
                return false;

            return true;
        }
    }
}
