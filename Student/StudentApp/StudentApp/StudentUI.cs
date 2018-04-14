using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    class StudentUI : DatabaseConnections
    {
        static public string StudentPrompt()
        {
            Console.WriteLine("What would you like to do?\n" +
                "(1) enroll in a course\n" +
                "(2) view my courses\n" +
                "(3) view all available courses\n");

            string useroption = Console.ReadLine();
            return useroption;
        }

        static public void HandleOption(string option)
        {
            if (option == "1")
            {
                Console.WriteLine("Enrolling in course...\n");
                string courseName = HandleEnrollment();
                Enroll(courseName);
                //EnrollInCourse();
            }
            else if (option == "2")
            {
                Console.WriteLine("Viewing my courses...\n");
                //ViewCourses();
            }
            else if (option == "3")
            {
                Console.WriteLine("Viewing all courses");
                ViewAllCourses();
            }
        }

        static public void ViewAllCourses()
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                Course.Select(conn);
                conn.Close();
            }
        }

        static public string HandleEnrollment()
        {
            Console.WriteLine("please enter the name of the course you want to enroll in.\n");
            string course = Console.ReadLine();
            return course;
        }

        static public void Enroll(string course)
        {
            Console.WriteLine($"Enrolling in {course}...\n");
        }
    }
}
