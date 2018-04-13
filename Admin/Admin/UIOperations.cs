using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class UIOperations : DatabaseConnections
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
                var ProfessorInfo = ProfessorPrompt();
                // Check the information if you so please.

                // Item 1 = name, Item2 = title
                var newProf = new Professor(ProfessorInfo.Item1, ProfessorInfo.Item2);
                // Insert into DB.
                using(var conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    newProf.Insert(conn);
                    conn.Close();
                }

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

        static public Tuple<string, string> ProfessorPrompt()
        {
            // DB takes in both a name and a title
            string name;
            string title;

            Console.WriteLine("What is your professor's name?\n");
            name = Console.ReadLine();

            Console.WriteLine("What is your professor's title? (Mr. Mrs. Dr, etc)\n");
            title = Console.ReadLine();

            Console.WriteLine($"{title} {name}");
            return Tuple.Create(name, title);
        }

        static public void ClassPrompt()
        {
            //Console.WriteLine("Time to create a new class");
            string courseNum;
            string Course_Level;
            string Course_Name;
            string Course_Room;
            string Start_Year;
            string Start_Month;
            string Start_Day;
            string Start_Hour;
            string Start_Minute;

            Console.WriteLine("What is the Course Number?\n");
            courseNum = Console.ReadLine();

            Console.WriteLine("What is the Course Level?\n");
            Course_Level = Console.ReadLine();

            Console.WriteLine("What is the Course Name?\n");
            Course_Name = Console.ReadLine();

            Console.WriteLine("What is the Course Room?\n");
            Course_Room = Console.ReadLine();


            // Getting date informtion
            // Will eventually need some validation. Break into own function.

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
