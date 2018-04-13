using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class DateTimeOperations
    {
        static public void DateTimePrompt()
        {
            string Start_Year;
            string Start_Month;
            string Start_Day;
            string Start_Hour;
            string Start_Minute;

            bool isValidDate = false;
            // Getting date informtion

            while (!isValidDate)
            {
                Console.WriteLine("What is the Start Year?\n");
                Start_Year = Console.ReadLine();
                isValidDate = CheckValidBounds(Start_Year, 0, int.MaxValue);
            }
            isValidDate = false;

            while(!isValidDate)
            {
                Console.WriteLine("What is the Start Month? (1-12)\n");
                Start_Month = Console.ReadLine();
                isValidDate = CheckValidBounds(Start_Month, 1, 12);
            }
            isValidDate = false;

            while (!isValidDate)
            {
                Console.WriteLine("What is the Start Day?\n");
                Start_Day = Console.ReadLine();
                isValidDate = CheckValidBounds(Start_Day, 1, 31);
            }
            isValidDate = false;

            while (!isValidDate)
            {
                Console.WriteLine("What is the Start Hour? (0-23)\n");
                Start_Hour = Console.ReadLine();
                isValidDate = CheckValidBounds(Start_Hour, 0, 23);
            }
            isValidDate = false;

            while (!isValidDate)
            {
                Console.WriteLine("What is the Start Minute? (0-59)\n");
                Start_Minute = Console.ReadLine();
                isValidDate = CheckValidBounds(Start_Minute, 0, 59);
            }

        }

        static public bool CheckValidBounds(string value, int lowerBound, int upperBound)
        {
            // Check if string can be a valid integer...
            if(Int32.TryParse(value, out int val)){
                // If so, compare it to the bounds.
                int checkedVal = Int32.Parse(value);
                if(lowerBound <= checkedVal && upperBound >= checkedVal)
                {
                    Console.WriteLine("This is a valid number!");
                    // Return True;
                    return true;
                } else
                {
                    Console.WriteLine("This is not a valid number. Please try again.");
                    // Return False;
                    return false;
                }
            } else
            {
                Console.WriteLine("You did not submit a valid number. Please Try again.");
                return false;
            }
        }
    }
}
