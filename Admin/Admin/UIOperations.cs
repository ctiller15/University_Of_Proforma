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

        static public void HandleUserChoice()
        {
            string userChoice = Console.ReadLine();
            if(userChoice == "1")
            {
                ProfessorPrompt();
            } else if (userChoice == "2")
            {
                ClassPrompt();
            } else if (userChoice == "3")
            {
                ViewEnrollments();
            } else if (userChoice == "4")
            {
                ViewClasses();
            } else
            {
                Console.WriteLine("Not a valid option");
            }

        }

        static public void ProfessorPrompt()
        {
            // DB takes in both a name and a title
            string name;
            string title;
            //Console.WriteLine("Time to add your professor!");
            Console.WriteLine("What is your professor's name?\n");
            name = Console.ReadLine();
            Console.WriteLine("What is your professor's title? (Mr. Mrs. Dr, etc)\n");
            title = Console.ReadLine();
            Console.WriteLine($"{title} {name}");
        }

        static public void ClassPrompt()
        {
            Console.WriteLine("Time to create a new class");
        }

        static public void ViewEnrollments()
        {
            Console.WriteLine("Viewing enrollments...");
        }

        static public void ViewClasses()
        {
            Console.WriteLine("Viewing classes...");
        }
    }
}
