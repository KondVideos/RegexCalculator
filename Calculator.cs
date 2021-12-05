using System;
using System.Text.RegularExpressions;
using System.Globalization;
using static System.Console;

namespace Kalkulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter your operation: ");
            string operation = ReadLine();
            WriteLine(Calculate(operation));
        }
        public static decimal Calculate(string operation)
        {
            string input = Regex.Replace(operation, @"\s+", "");
            if(!Regex.IsMatch(input, @"^[0-9]+[\.]?[0-9]{0,}[/-x\*\+]{1}[0-9]+[\.]?[0-9]{0,}$"))
            {
                throw new Exception("Invalid input");
            }
            string[] splitInput = Regex.Split(input, @"(-)|(/)|(x)|(\*)|(\+)"); 
            
            decimal numberOne = decimal.Parse(splitInput[0], CultureInfo.InvariantCulture);
            decimal numberTwo = decimal.Parse(splitInput[2], CultureInfo.InvariantCulture);

            checked
            {
                return splitInput[1] switch
                {
                    "-" => numberOne - numberTwo,
                    "+" => numberOne + numberTwo,
                    "*" or "x" => numberOne * numberTwo,
                    "/" => numberTwo == 0 ? throw new Exception("Can't divide by zero") : numberOne / numberTwo,
                    _ => throw new Exception("Invalid operator")
                };
            }
        }
    }   
}
