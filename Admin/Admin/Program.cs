using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class Program
    {


        static void Main(string[] args)
        {
            // Get the database location.
            const string CONNECTION_STRING =
    @"Server=localhost\SQLEXPRESS;Database=University_Of_Proforma;Trusted_Connection=True;";

            UIOperations.IntroduceUser();
            UIOperations.DisplayOptions();
            Console.ReadLine();

            // Open the connection
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                var newProf = new Professor
                {
                    Professor_Name = "Ordetx",
                    Professor_Title = "Mrs."
                };

                var newerProf = new Professor
                {
                    Professor_Name = "Costas",
                    Professor_Title = "Dr.",
                };
                conn.Open();
                newProf.Insert(conn);
                newerProf.Insert(conn);

                var newCourse = new Course
                {
                    Course_Number = 1,
                    Course_Level = 100,
                    Course_Name = "Intro to C#",
                    Course_Room = "VAB101",
                    Start_Time = DateTime.Now
                };
                newCourse.Insert(conn);

            }
        }
    }
}
