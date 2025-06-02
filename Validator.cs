using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6.Utilities
{
    public static class Validator
    {
        public static bool IsStringValid(string str)
            => !string.IsNullOrWhiteSpace(str) && str.All(char.IsLetter);

        public static bool IsNumberValid(string num)
            => !string.IsNullOrWhiteSpace(num) && num.All(char.IsDigit);
        public static bool IsDateValid(DateTime date)
            => date != DateTime.MinValue && date != DateTime.MaxValue;
        public static bool IsPriceValid(int price)
            => price >= 0 && IsNumberValid(price.ToString());
        public static bool IsPasswordValid(string password)
            => !string.IsNullOrWhiteSpace(password);
        public static bool IsBoolValid(bool value)
            => value == true || value == false;
    }
}