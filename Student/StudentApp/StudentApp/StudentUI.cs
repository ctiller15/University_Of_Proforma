using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    class StudentUI
    {
        static public string StudentPrompt()
        {
            Console.WriteLine("What would you like to do?\n" +
                "(1) enroll in a course\n" +
                "(2) view my courses\n");

            string useroption = Console.ReadLine();
            return useroption;
        }

        static public void HandleOption(string option)
        {
            if(option == "1")
            {
                Console.WriteLine("Enrolling in course...\n");
                //EnrollInCourse();
            } else if(option == "2")
            {
                Console.WriteLine("Viewing my courses...\n");
                //ViewCourses();
            }
        }
    }
}
