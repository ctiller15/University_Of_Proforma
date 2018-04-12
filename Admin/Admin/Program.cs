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
        static void InsertProfessor(SqlConnection conn, Professor prof)
        {
            var _insert = "INSERT INTO PROFESSORS (Name, Title)" +
                "VALUES (@Name, @Title)";

            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("Name", prof.Professor_Name);
            cmd.Parameters.AddWithValue("Title", prof.Professor_Title);
            cmd.ExecuteScalar();
        }

        static void Main(string[] args)
        {
            // Get the database location.
            const string CONNECTION_STRING =
    @"Server=localhost\SQLEXPRESS;Database=University_Of_Proforma;Trusted_Connection=True;";

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
                InsertProfessor(conn, newProf);
                InsertProfessor(conn, newerProf);

            }
        }
    }
}
