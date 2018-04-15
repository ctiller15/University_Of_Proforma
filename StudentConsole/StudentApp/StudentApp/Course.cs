using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    class Course : ISQLOperations
    {
        public int Course_ID { get; set; }
        public int Course_Number { get; set; }
        public int Course_Level { get; set; }
        public string Course_Name { get; set; }
        public string Course_Room { get; set; }
        public DateTime Start_Time { get; set; }

        // Inserts course into database
        public void Insert(SqlConnection conn)
        {
            var _insert = "INSERT INTO COURSES (Number, Course_Level, Course_Name, Course_Room, Start_Time)" +
                "VALUES (@Number, @Course_Level, @Course_Name, @Course_Room, @Start_Time)";

            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("Number", this.Course_Number);
            cmd.Parameters.AddWithValue("Course_Level", this.Course_Level);
            cmd.Parameters.AddWithValue("Course_Name", this.Course_Name);
            cmd.Parameters.AddWithValue("Course_Room", this.Course_Room);
            cmd.Parameters.AddWithValue("Start_Time", this.Start_Time);
            cmd.ExecuteScalar();
        }

        //static List<Student> GetStudentByCourse(SqlConnection conn, string courseName)
        //{
        //    // query database.
        //    var _select = "SELECT * " +
        //        "FROM Courses " +
        //        "JOIN Enrollment ON Courses.Course_ID = Enrollment.Enroll_ID " +
        //        "JOIN Students ON Enrollment.Student_ID = Students.Student_ID " +
        //        $"WHERE Course_Name = '{courseName}' ";

        //    var query = new SqlCommand(_select, conn);
        //    conn.Open();
        //    var reader = query.ExecuteReader();
        //    var _rv = new List<Student>();
        //    // parse results.
        //    while (reader.Read())
        //    {
        //        var _student = new Student(reader);
        //        Console.WriteLine($"{_student.FullName}");
        //    }
        //    conn.Close();
        //    return _rv;
        //}

            // Could potentially use enums to differentiate between the different searches.
        static public void Select(SqlConnection conn)
        {
            var _select = "SELECT Course_ID, Course_Name " +
                "FROM[dbo].[Courses] ";

            var query = new SqlCommand(_select, conn);
            var reader = query.ExecuteReader();
            var _rv = new List<string>();
            // parse results.
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Course_ID"].ToString()} , {reader["Course_Name"].ToString()}");
            }
        }

        public Course(int num, int level, string name, string room, DateTime time)
        {
            this.Course_Number = num;
            this.Course_Level = level;
            this.Course_Name = name;
            this.Course_Room = room;
            this.Start_Time = time;
        }

        public Course(SqlDataReader reader)
        {
            this.Course_Number = Int32.Parse(reader["Number"].ToString());
            this.Course_Level = Int32.Parse(reader["Course_Level"].ToString());
            this.Course_Name = reader["Course_Name"].ToString();
            this.Course_Room = reader["Course_Room"].ToString();
            this.Start_Time = DateTime.Parse(reader["Start_Time"].ToString());
        }
    }
}
