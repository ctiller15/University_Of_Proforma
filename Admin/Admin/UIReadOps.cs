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
                "(2) View Classes, PRofessors, and enrollments\n");

            string userchoice = Console.ReadLine();
            return userchoice;
        }

        static public bool HandleReadOperations(string userchoice)
        {
            if (userchoice == "1")
            {
                Console.WriteLine("Viewing class enrollments...\n");
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
            return true;
        }

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
    }
}
