/*
 * Jonathan Daniel
 * ITSE 1430 - Fall 2021
 */
/*
 * file header
 * Your Name
 * ITSE 1430 Fall 2021
 */
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main ( string[] args )
        {
            // Single line
            int xyz = 0;
            int _name;
            //int 1notValid;
            int first_name;  //Valid but not recommended
            int firstName;

            int grade1;
            grade1 = 0;

            int grade_1;
            //int @if;
            int x = 4, y = 5;
            int z = x + y;

            //nested scope
            {
                double grade2;
            }
            //grade2; //out of scope

            Console.WriteLine("Hello World!");

            /* Multiline comment
             */
            //Logical 2

            //Declare some primitives
            sbyte code = 10;
            short port = 1_2_34;
            int hours = 45;
            long debtPaybackInYears = 10_000;

            byte errorCode = 0xAF;
            ushort errorPort = 0x145;
            uint unpaidHours = 0b1001_1110_1010_0010;

            double hoursWorked = 80.9;
            decimal payRate = 12.50M;

            char letter = 'A';
            string name = "Bob";

            //Not primitive
            DateTime today = DateTime.Now;
            TimeSpan interval = TimeSpan.FromMinutes(10);
            Guid identifier = Guid.Empty;
        }

        //Demoing the logical operators
        static void DemoLogicalOperators ()
        {
            // Logical AND - true if both operands are true
            // Logical OR - true if either operand is true
            //    X   Y  &&   ||
            //==========================
            //    F   F   F   F
            //    F   T   F   T
            //    T   F   F   T
            //    T   T   T   T

            // NOT
            //     F  !F = T
            //     T  !T = F
        }

        static void DemoRelationalOperators ()
        {
            int x = 10, y = 20;

            bool isLessThan = x < y;
            bool isLessThanOrEqualTo = x <= y;

            bool isGreaterThan = x > y;
            bool isGreaterThanOrEqualTo = x >= y;

            bool isEqual = x == y;
            bool isNotEqual = x != y;
        }

        static void DemoCombinationOperators ()
        {
            //Works for more than just arithmetic
            int x = 10;

            x += 10;  // x = x + 10
            x -= 20;  // x = x - 20
            x *= 3;   // x = x * 3
            x /= 5;   // x = x / 5
            x %= 2;   // x = x % 2
        }

        static void DemoPrefixPostfixOperators ()
        {
            int x = 10, y;

            //Prefix increment
            //  1. Take current value of x and increment by 1
            //  2. Store new value back in x
            //  3. Expression value is current value of x
            y = ++x; //x = 11, y = 11

            //Prefix decrement
            //  1. Take current value of x and decrement by 1
            //  2. Store new value back in x
            //  3. Expression value is current value of x
            y = --x; //x = 10, y = 10

            //Postfix increment
            //  1. Store current value of x in Tmp
            //  2. Increment x by one and store back in x
            //  3. Expression value is Tmp (original value of x)
            y = x++; //x = 11, y = 10

            //Postfix decrement
            //  1. Store current value of x in Tmp
            //  2. Decrement x by one and store back in x
            //  3. Expression value is Tmp (original value of x)
            y = x--; //x = 10, y = 11
        }

        static void DemoAssignmentOperator ()
        {
            int x;
            int y;
            int z;

            x = 10;
            y = 10;
            z = 10;

            //left associative (E1 op E2) => E1, E2, op
            //right associative operators (E1 op E2) => E2, E1, op
            x = y = z = 20; // x = (y = (z = 20))
        }

        static void DemoConditionalOperator ()
        {
            int grade = 70;
            
            string passStatus;

            if (grade < 60)
                passStatus = "Not Passing";
            else
                passStatus = "Passing";

            //Terninary - 3 operands
            // E(bool) ? E(true) : E(false)
            string passStatus2 = (grade < 60) ? "Not Passing" : "Passing";
        }

        static void DemoString ()
        {
            string firstName = "Bob";

            //Relationals work, case sensitive
            bool isBob = firstName == "Bob";

            //String literals
            string literal1 = "Hello World";

            //Escape sequence - \?, only work in string literals
            //  \n => newline
            //  \t => horizontal tab
            //  \\ => slash
            //  \" => double quote
            //  \' => character literal, single quote
            literal1 = "Hello\nWorld";
            string quoteString = "Hello \"Bob\"";

            string filePath = "C:\\windows\\system32\\tasks";
            string verbatimFilePath = @"C:\windows\system32\tasks";

            //String length `.Length` => How many characters
            int length = literal1.Length;

            //Empty string
            string emptyString = ""; //.Length = 0
            string emptyString2 = String.Empty; //.Length = 0
            bool areEmptyStringsEqual = String.Empty == ""; // True

            // null != empty string
            // default value for strings is null
            string nullString = null;
            bool areEqualNull = "" == null; // False

            // string is the universal type in C#
            // all expressions are convertible to string using .ToString
            string asString = length.ToString(); // length as a string
            asString = 10.ToString(); // "10"
            asString = areEqualNull.ToString(); //"False"
        }
    }
}
