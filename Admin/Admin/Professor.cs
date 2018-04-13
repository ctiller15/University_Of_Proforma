using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class Professor : ISQLOperations
    {
        public int Professor_ID { get; set; }
        public string Professor_Name { get; set; }
        public string Professor_Title { get; set; }

        // Inserts SQL data into database.
        public void Insert(SqlConnection conn)
        {
            var _insert = "INSERT INTO PROFESSORS (Name, Title)" +
                "VALUES (@Name, @Title)";

            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("Name", this.Professor_Name);
            cmd.Parameters.AddWithValue("Title", this.Professor_Title);
            cmd.ExecuteScalar();
        }

        public Professor()
        {

        }

        public Professor(string name, string title)
        {
            this.Professor_Name = name;
            this.Professor_Title = title;
        }
    }
}
