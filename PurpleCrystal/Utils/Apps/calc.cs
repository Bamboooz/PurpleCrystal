using System;
using static PurpleCrystal.Utils.Tools.Shortcuts;
using static PurpleCrystal.Prompt.Commands;

namespace PurpleCrystal.Utils.Apps
{
    public static class calc {

        public static string string1;
        public static string string2;
        public static double num1;
        public static double num2;
        public static string operationType;

        static public bool IsIntegerString(string number)
        {
            for (int i = 0; i < number.Length; ++i)
            {
                if (i != 0 && number[i] == '-')
                {
                    return false;
                }
                else if (number[i] < '0' || number[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }

        public static void simplecalc() {

            Console.WriteLine();

            num1 = 0;
            num2 = 0;
            operationType = "";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("PurpleCrystal Simple Calc:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter 1st Num:");
            Console.ForegroundColor = ConsoleColor.White;
            user_text();
            var input = Console.ReadLine();
            string1 = input;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Choose Operation Type:");
            Console.WriteLine("+");
            Console.WriteLine("-");
            Console.WriteLine("*");
            Console.WriteLine("/");

            Console.ForegroundColor = ConsoleColor.White;
            user_text();
            var input1 = Console.ReadLine();
            operationType = input1;

            if (operationType == "+" || operationType == "-" || operationType == "/" || operationType == "*") {
                calcNum2();
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Operation Type Cannot Be Diffrent Than ' +, -, *, / '");
                Console.ForegroundColor = ConsoleColor.White;
                simplecalc();
            }

        }

        public static void calcNum2()
        {

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter 2nd Num:");
            Console.ForegroundColor = ConsoleColor.White;
            user_text();
            var input2 = Console.ReadLine();
            string2 = input2;

            containsLetter();

        }

        public static void maxIntCheck()
        {

            num1 = long.Parse(string1);
            num2 = long.Parse(string2);
            
            if (num1 < 2147483646 && num2 < 2147483646 && num1 > -2147483646 && num2 > -2147483646) {
                    calcPrintOutput();
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number Cannot Be Bigger Than 2147483646.");
                Console.ForegroundColor = ConsoleColor.White;
                simplecalc();
            }

        }

        public static void containsLetter()
        {

            if (IsIntegerString(string1) && IsIntegerString(string2))
            {
                maxIntCheck();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number Cannot Contain Letters.");
                Console.ForegroundColor = ConsoleColor.White;
                simplecalc();
            }

        }

        public static void calcPrintOutput()
        {

            if (operationType == "+")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Simple Calc: " + num1 + operationType + num2 + " = ");
                Console.WriteLine(num1 + num2);
                Console.ForegroundColor = ConsoleColor.White;
                new_command();
            }
            else if (operationType == "-")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Simple Calc: " + num1 + operationType + num2 + " = ");
                Console.WriteLine(num1 - num2);
                Console.ForegroundColor = ConsoleColor.White;
                new_command();
            }
            else if (operationType == "/")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Simple Calc: " + num1 + operationType + num2 + " = ");
                Console.WriteLine(num1 / num2);
                Console.ForegroundColor = ConsoleColor.White;
                new_command();
            }
            else if (operationType == "*")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Simple Calc: " + num1 + operationType + num2 + " = ");
                Console.WriteLine(num1 * num2);
                Console.ForegroundColor = ConsoleColor.White;
                new_command();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Operation Type Is Not Valid.");
                Console.ForegroundColor = ConsoleColor.White;
                new_command();
            }

        }

    }
}