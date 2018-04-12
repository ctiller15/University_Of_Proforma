using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class Course
    {
        public int Course_ID { get; set; }
        public int Course_Number { get; set; }
        public int Course_Level { get; set; }
        public string Course_Name { get; set; }
        public string Course_Room { get; set; }
        public DateTime Start_Time { get; set; }

        static public void InsertCourse(SqlConnection conn, Course course)
        {
            var _insert = "INSERT INTO COURSES (Number, Course_Level, Course_Name, Course_Room, Start_Time)" +
                "VALUES (@Number, @Course_Level, @Course_Name, @Course_Room, @Start_Time)";

            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("Number", course.Course_Number);
            cmd.Parameters.AddWithValue("Course_Level", course.Course_Level);
            cmd.Parameters.AddWithValue("Course_Name", course.Course_Name);
            cmd.Parameters.AddWithValue("Course_Room", course.Course_Room);
            cmd.Parameters.AddWithValue("Start_Time", course.Start_Time);
            cmd.ExecuteScalar();
        }
    }
}
