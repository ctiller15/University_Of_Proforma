using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class UIOperations
    {
        static public void IntroduceUser()
        {
            Console.WriteLine("Hello, and Welcome to the Proforma University Administration panel!\n" +
                "What would you like to do?\n");
        }

        static public void DisplayOptions()
        {
            Console.WriteLine($"(1) Add a Professor\n" +
                $"(2) Add a Class\n" +
                $"(3) View all students enrolled in a class\n" +
                $"(4) View all classes, teachers, and students\n");
        }
    }
}
