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
                string student = PromptStudent();
                ViewStudentCourses(student);
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
            Console.WriteLine("Please enter the ID of the student. \n");
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

        static public void ViewStudentCourses(string student) {
            Console.WriteLine($"Viewing student courses...\n");
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                var _select = "SELECT Course_Name, Students.Student_ID " +
                            "FROM[dbo].[Students] " +
                            "JOIN Enrollment ON Students.Student_ID = Enrollment.Student_ID " +
                            "JOIN Courses ON Enrollment.Course_ID = Courses.Course_ID " +
                            $"WHERE Students.Student_ID = {student} ";

                var query = new SqlCommand(_select, conn);
                var reader = query.ExecuteReader();
                var _rv = new List<string>();
                // parse results.
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Course_Name"].ToString()}");
                }
            }
        }
    }
}
