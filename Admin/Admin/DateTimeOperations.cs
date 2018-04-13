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
            int Start_Year;
            int Start_Month;
            int Start_Day;
            int Start_Hour;
            int Start_Minute;

            //bool isValidDate = false;
            // Getting date informtion

            //while (!isValidDate)
            //{
            //    Console.WriteLine("What is the Start Year?\n");
            //    Start_Year = Console.ReadLine();
            //    isValidDate = CheckValidBounds(Start_Year, 0, int.MaxValue);
            //}
            //isValidDate = false;
            Start_Year = PromptIndividualDateNumber("What is the Start Year?\n", 0, int.MaxValue);

            Start_Month = PromptIndividualDateNumber("What is the Start Month? (1-12)\n", 1, 12);
            //while(!isValidDate)
            //{
            //    Console.WriteLine("What is the Start Month? (1-12)\n");
            //    Start_Month = Console.ReadLine();
            //    isValidDate = CheckValidBounds(Start_Month, 1, 12);
            //}
            //isValidDate = false;

            //while (!isValidDate)
            //{
            //    Console.WriteLine("What is the Start Day?\n");
            //    Start_Day = Console.ReadLine();
            //    isValidDate = CheckValidBounds(Start_Day, 1, 31);
            //}
            //isValidDate = false;
            Start_Day = PromptIndividualDateNumber("What is the Start Day?\n", 1, 31);

            //while (!isValidDate)
            //{
            //    Console.WriteLine("What is the Start Hour? (0-23)\n");
            //    Start_Hour = Console.ReadLine();
            //    isValidDate = CheckValidBounds(Start_Hour, 0, 23);
            //}
            //isValidDate = false;

            Start_Hour = PromptIndividualDateNumber("What is the Start Hour? (0-23)\n", 0, 23);

            //while (!isValidDate)
            //{
            //    Console.WriteLine("What is the Start Minute? (0-59)\n");
            //    Start_Minute = Console.ReadLine();
            //    isValidDate = CheckValidBounds(Start_Minute, 0, 59);
            //}

            Start_Minute = PromptIndividualDateNumber("What is the Start Minute? (0-59)\n", 0, 59);

        }

        // Checks if a string representation of a number fits a given set of numeric bounds.
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

        static int PromptIndividualDateNumber(string prompt, int lower, int upper)
        {
            bool isValidDate = false;
            string promptAnswer = "";

            while (!isValidDate)
            {
                //Console.WriteLine("What is the Start Year?\n");
                Console.WriteLine(prompt);
                promptAnswer = Console.ReadLine();
                isValidDate = CheckValidBounds(promptAnswer, lower, upper);
            }
            return Int32.Parse(promptAnswer);
        }
    }
}
