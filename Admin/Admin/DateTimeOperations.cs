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

            // Getting date informtion

            Console.WriteLine("What is the Start Year?");
            Start_Year = Console.ReadLine();

            Console.WriteLine("What is the Start Month?\n");
            Start_Month = Console.ReadLine();

            Console.WriteLine("What is the Start Day?\n");
            Start_Day = Console.ReadLine();

            Console.WriteLine("What is the Start Hour? (0-24)");
            Start_Hour = Console.ReadLine();

            Console.WriteLine("What is the Start Minute? (0-59)");
            Start_Minute = Console.ReadLine();
        }
    }
}
