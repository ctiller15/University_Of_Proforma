using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class UIReadOps
    {
        static public string ShowReadOperations()
        {
            Console.WriteLine("(1) View class Enrollments\n" +
                "(2) View Classes, PRofessors, and enrollments\n");

            string userchoice = Console.ReadLine();
            return userchoice;
        }

        static public bool HandleReadOperations(string userchoice)
        {
            if (userchoice == "1")
            {
                Console.WriteLine("Viewing class enrollments...\n");
            }
            else if (userchoice == "2")
            {
                Console.WriteLine("Viewing everything...");
            }
            return true;
        }
    }
}
