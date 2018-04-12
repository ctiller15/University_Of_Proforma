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
                Professor.InsertProfessor(conn, newProf);
                Professor.InsertProfessor(conn, newerProf);

            }
        }
    }
}
