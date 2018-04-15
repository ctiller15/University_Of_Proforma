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
            //Console.WriteLine($"(1) Add a Professor\n" +
            //    $"(2) Add a Class\n" +
            //    $"(3) Add a Student\n" +
            //    $"(4) View all students enrolled in a class\n" +
            //    $"(5) View all classes, teachers, and students\n");
            Console.WriteLine($"(1) Create a Professor, Class, Student, etc.");
        }

        static public void HandleUserChoice()
        {

            string userChoice = Console.ReadLine();
            if(userChoice == "1")
            {
                bool chosen = false;
                // Move to create menu.
                while(!chosen == true)
                {
                    string choice = UICreateOps.ShowCreateOperations();
                    chosen = UICreateOps.HandleCreateOperations(choice);
                }
            } else if(userChoice == "2")
            {
                bool chosen = false;
                // move to read menu.
                while (!chosen == true)
                {
                    string choice = UIReadOps.ShowReadOperations();
                    chosen = UIReadOps.HandleReadOperations(choice);
                }
                //UIReadOps.ShowReadOperations();
            }
            //if (userChoice == "1")
            //{
            //    var ProfessorInfo = ProfessorPrompt();
            //    // Check the information if you so please.

            //    // Item 1 = name, Item2 = title
            //    var newProf = new Professor(ProfessorInfo.Item1, ProfessorInfo.Item2);
            //    // Insert into DB.
            //    using (var conn = new SqlConnection(CONNECTION_STRING))
            //    {
            //        conn.Open();
            //        newProf.Insert(conn);
            //        conn.Close();
            //        Console.WriteLine("Professor created successfully");
            //    }

            //}
            //else if (userChoice == "2")
            //{
            //    var ClassInfo = ClassPrompt();

            //    // Item1 = Number, Item2 = Level, Item3 = Course Name, Item4 = Course Room, Item5 = Start Time.
            //    var newClass = new Course(ClassInfo.Item1, ClassInfo.Item2, ClassInfo.Item3, ClassInfo.Item4, ClassInfo.Item5);
            //    // Insert into DB.
            //    using (var conn = new SqlConnection(CONNECTION_STRING))
            //    {
            //        conn.Open();
            //        newClass.Insert(conn);
            //        conn.Close();
            //        Console.WriteLine("Course created successfully");
            //    }
            //}
            //else if (userChoice == "3")
            //{
            //    var StudentInfo = StudentPrompt();

            //    // Item1 = Full Name, Item2 = Email, Item3 = PhoneNumber, Item4 = Major.
            //    var newStudent = new Student(StudentInfo.Item1, StudentInfo.Item2, StudentInfo.Item3, StudentInfo.Item4);
            //    // Insert Into DB.
            //    using (var conn = new SqlConnection(CONNECTION_STRING))
            //    {
            //        conn.Open();
            //        newStudent.Insert(conn);
            //        conn.Close();
            //        Console.WriteLine("Student created successfully");
            //    }
            //}
            else if (userChoice == "4")
            {
                ViewEnrollments();
            }
            else if (userChoice == "5")
            {
                ViewClasses();
            }
            else
            {
                Console.WriteLine("Not a valid option");
            }

        }

        // Prompts for a professor name/title, and returns the result.
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

        // Prompts for a course's information, and returns the result.
        static public Tuple<int, int, string, string, DateTime> ClassPrompt()
        {
            //Console.WriteLine("Time to create a new class");
            int courseNum;
            int Course_Level;
            string Course_Name;
            string Course_Room;

            Console.WriteLine("What is the Course Number?\n");
            courseNum = Int32.Parse(Console.ReadLine());

            Console.WriteLine("What is the Course Level?\n");
            Course_Level = Int32.Parse(Console.ReadLine());

            Console.WriteLine("What is the Course Name?\n");
            Course_Name = Console.ReadLine();

            Console.WriteLine("What is the Course Room?\n");
            Course_Room = Console.ReadLine();

            int[] DateTimeValues = DateTimeOperations.DateTimePrompt();
            var CourseDate = new DateTime(DateTimeValues[0], DateTimeValues[1], DateTimeValues[2], DateTimeValues[3], DateTimeValues[4], 0);
            Console.WriteLine(CourseDate);
            return Tuple.Create(courseNum, Course_Level, Course_Name, Course_Room, CourseDate);
        }

        // prompt for a students information and return the result.
        static public Tuple<string, string, string, string> StudentPrompt()
        {
            //Console.WriteLine("Adding a student...");
            string FullName;
            string Fname;
            string Lname;
            string Email;
            string PhoneNumber;
            string Major;

            Console.WriteLine("What is the First Name?");
            Fname = Console.ReadLine();

            Console.WriteLine("What is the Last Name?");
            Lname = Console.ReadLine();

            FullName = $"{Fname} {Lname}";

            Console.WriteLine("What is the email?");
            Email = Console.ReadLine();

            Console.WriteLine("What is the phone number?");
            PhoneNumber = Console.ReadLine();

            Console.WriteLine("What is the major?");
            Major = Console.ReadLine();

            return Tuple.Create(FullName, Email, PhoneNumber, Major);
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