using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class UIReadOps : UIOperations
    {
        static public string ShowReadOperations()
        {
            Console.WriteLine("(1) View class Enrollments\n" +
                "(2) View Classes, Professors, and enrollments\n" +
                "(3) View Professors\n" +
                "(4) View Students\n" +
                "(5) View Courses \n");

            string userchoice = Console.ReadLine();
            return userchoice;
        }

        static public bool HandleReadOperations(string userchoice)
        {
            if (userchoice == "1")
            {
                Console.WriteLine("Viewing class enrollments...\n");
                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    Console.WriteLine("Which course would you like to see the students of?\n");

                    //string courseName = "Intro to C#";
                    string courseName = Console.ReadLine();
                    var stud = GetStudentByCourse(conn, courseName);
                }
            }
            else if (userchoice == "2")
            {
                Console.WriteLine("Viewing everything...");
            } else if (userchoice == "3")
            {
                Console.WriteLine("Viewing professors...");
                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    var prof = GetAllProfessors(conn);
                }

            } 
            else if (userchoice == "4")
            {
                //Console.WriteLine("Viewing students...");


            } else if (userchoice == "5") {
                Console.WriteLine("Viewing Courses...");
                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    var courses = GetAllCourses(conn);
                }
            }
            return true;
        }

        // Query to select all students in a given course:
 //       SELECT FullName AS 'Enrolled_Students'
	//FROM[dbo].[Courses]
 //       JOIN Enrollment ON Courses.Course_ID = Enrollment.Enroll_ID
 //       JOIN Students ON Enrollment.Student_ID = Students.Student_ID
    
 //       WHERE Course_Name = 'Intro to C#';

        static List<Professor> GetAllProfessors(SqlConnection conn)
        {
            // Query database.
            var _select = "SELECT *" +
                "FROM Professors";

            var query = new SqlCommand(_select, conn);
            conn.Open();
            var reader = query.ExecuteReader();
            var _rv = new List<Professor>();
            // parse results.
            while (reader.Read())
            {
                var _prof = new Professor(reader);
                Console.WriteLine($"{_prof.Professor_Name} , {_prof.Professor_Title}");
            }
            conn.Close();
            return _rv;
        }

        static List<Student> GetStudentByCourse(SqlConnection conn, string courseName)
        {
            // query database.
            var _select = "SELECT * " +
                "FROM Courses " +
                "JOIN Enrollment ON Courses.Course_ID = Enrollment.Enroll_ID " +
                "JOIN Students ON Enrollment.Student_ID = Students.Student_ID " +
                $"WHERE Course_Name = '{courseName}' ";

            var query = new SqlCommand(_select, conn);
            conn.Open();
            var reader = query.ExecuteReader();
            var _rv = new List<Student>();
            // parse results.
            while (reader.Read())
            {
                var _student = new Student(reader);
                Console.WriteLine($"{_student.FullName}");
            }
            conn.Close();
            return _rv;
        }

        static List<Course> GetAllCourses(SqlConnection conn)
        {
            // Query database.
            var _select = "SELECT *" +
                "FROM Courses";

            var query = new SqlCommand(_select, conn);
            conn.Open();
            var reader = query.ExecuteReader();
            var _rv = new List<Course>();
            // parse results.
            while (reader.Read())
            {
                var _course = new Course(reader);
                Console.WriteLine($"{_course.Course_Name}");
            }
            conn.Close();
            return _rv;
        }
    }
}
