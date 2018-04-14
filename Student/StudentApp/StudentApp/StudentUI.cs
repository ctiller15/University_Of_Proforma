using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    class StudentUI
    {
        static public void StudentPrompt()
        {
            Console.WriteLine("What would you like to do?\n" +
                "(1) enroll in a course\n" +
                "(2) view my courses\n");

            Console.ReadLine();
        }
    }
}
