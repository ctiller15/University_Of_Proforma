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
                string student = PromptStudent();
                Enroll(courseName, student);
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
            Console.WriteLine("please enter the ID of the course you want to enroll in.\n");
            string course = Console.ReadLine();
            return course;
        }

        static public string PromptStudent()
        {
            Console.WriteLine("Please enter the ID of the student who wishes to enroll. \n");
            string student = Console.ReadLine();
            return student;
        }

        static public void Enroll(string course, string user)
        {
            Console.WriteLine($"Enrolling student {user} in course of ID: {course}...\n");
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                var _insert = "INSERT INTO Enrollment (Course_ID, Student_ID)" +
                    "VALUES (@Course_ID, @Student_ID)";

                var cmd = new SqlCommand(_insert, conn);

                cmd.Parameters.AddWithValue("Course_ID", course);
                cmd.Parameters.AddWithValue("Student_ID", user);

                cmd.ExecuteScalar();
                conn.Close();
            }

            

        }
    }
}
