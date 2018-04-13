using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class UICreateOps : UIOperations
    {
        static public string ShowCreateOperations()
        {
            Console.WriteLine("(1) Create a Professor\n" +
                "(2) Create a new Course\n" +
                "(3) Create a Student\n");
            string userchoice = Console.ReadLine();
            return userchoice;
        }

        static public bool HandleCreateOperations(string userChoice)
        {
            if (userChoice == "1")
            {
                var ProfessorInfo = ProfessorPrompt();
                // Check the information if you so please.

                // Item 1 = name, Item2 = title
                var newProf = new Professor(ProfessorInfo.Item1, ProfessorInfo.Item2);
                // Insert into DB.
                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    newProf.Insert(conn);
                    conn.Close();
                    Console.WriteLine("Professor created successfully");
                }

            }
            else if (userChoice == "2")
            {
                var ClassInfo = ClassPrompt();

                // Item1 = Number, Item2 = Level, Item3 = Course Name, Item4 = Course Room, Item5 = Start Time.
                var newClass = new Course(ClassInfo.Item1, ClassInfo.Item2, ClassInfo.Item3, ClassInfo.Item4, ClassInfo.Item5);
                // Insert into DB.
                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    newClass.Insert(conn);
                    conn.Close();
                    Console.WriteLine("Course created successfully");
                }
            }
            else if (userChoice == "3")
            {
                var StudentInfo = StudentPrompt();

                // Item1 = Full Name, Item2 = Email, Item3 = PhoneNumber, Item4 = Major.
                var newStudent = new Student(StudentInfo.Item1, StudentInfo.Item2, StudentInfo.Item3, StudentInfo.Item4);
                // Insert Into DB.
                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    newStudent.Insert(conn);
                    conn.Close();
                    Console.WriteLine("Student created successfully");
                }
            }
            return true;
        }
    }
}
