using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AltexSoftTestTask
{
    class Program
    {
        private const string _quitSymbol = "q";
        private static readonly Regex _numberRegex = new Regex("^[0-9]+$");

        private static bool IsNumberValid(string number)
        {
            return _numberRegex.IsMatch(number) && number.Length >= 4 && number.Length <= 8;
        }

        private static string AddZeroOnBegin(string number)
        {
            return $"0{number}";
        }

        private static int[] ConvertStringToIntArray(string number)
        {
            return number.Select(c => c - '0').ToArray();
        }

        private static void CalculateLuckyNumber(string number)
        {
            if (!IsNumberValid(number))
            {
                Console.WriteLine("The input value is invalid, number has to be 4 to 8 digits long.");

                return;
            }

            if (number.Length % 2 == 1)
            {
                number = AddZeroOnBegin(number);
            }

            var midIndex = number.Length / 2;
            var firstHalf = ConvertStringToIntArray(number.Substring(0, midIndex));
            var secondHalf = ConvertStringToIntArray(number.Substring(midIndex));

            if (firstHalf.Sum() == secondHalf.Sum())
            {
                Console.WriteLine("Congrats, your number is lucky!");
            }
            else
            {
                Console.WriteLine("Unfortunately, your number is not lucky.");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"Enter the ticket number, for exit enter 'q'.");

                var enteredValue = Console.ReadLine();

                if (enteredValue.ToLower() == _quitSymbol)
                {
                    return;
                }

                CalculateLuckyNumber(enteredValue);
            }
        }
    }
}