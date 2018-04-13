using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
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

        public Course(int num, int level, string name, string room, DateTime time)
        {
            this.Course_Number = num;
            this.Course_Level = level;
            this.Course_Name = name;
            this.Course_Room = room;
            this.Start_Time = time;
        }
    }
}
