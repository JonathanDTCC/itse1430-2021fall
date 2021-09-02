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
    }
}
