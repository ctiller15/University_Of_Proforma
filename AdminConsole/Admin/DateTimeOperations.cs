using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class DateTimeOperations
    {
        static public int[] DateTimePrompt()
        {
            // 0 = Year, 1 = Month, 2 = Day, 3 = Hour, 4 = Minute
            PromptInfo[] dateTimeInfo = new PromptInfo[5] {
                new PromptInfo("What is the Start Year?\n", 0, int.MaxValue),
                new PromptInfo("What is the Start Month? (1-12)\n", 1, 12),
                new PromptInfo("What is the Start Day?\n", 1, 31),
                new PromptInfo("What is the Start Hour? (0-23)\n", 0, 23),
                new PromptInfo("What is the Start Minute? (0-59)\n", 0, 59)
            };

            int[] DateTimeResult = new int[5];
            // Getting date informtion

            for(int i = 0; i < dateTimeInfo.Length; i++)
            {
                DateTimeResult[i] = PromptIndividualDateNumber(dateTimeInfo[i].PromptText, dateTimeInfo[i].LowerBound, dateTimeInfo[i].UpperBound);
            }
            return DateTimeResult;
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
                    return true;
                } else
                {
                    Console.WriteLine("This is not a valid number. Please try again.");
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
                Console.WriteLine(prompt);
                promptAnswer = Console.ReadLine();
                isValidDate = CheckValidBounds(promptAnswer, lower, upper);
            }
            return Int32.Parse(promptAnswer);
        }
    }
}
