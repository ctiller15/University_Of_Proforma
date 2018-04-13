using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class Student : ISQLOperations
    {
        public int Student_ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Major { get; set; }

        // Insert into SQL database.
        public void Insert(SqlConnection conn)
        {
            var _insert = "INSERT INTO STUDENTS (FullName, Email, PhoneNumber, Major)" +
                "VALUES (@FullName, @Email, @PhoneNumber, @Major)";

            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("FullName", this.FullName);
            cmd.Parameters.AddWithValue("Email", this.Email);
            cmd.Parameters.AddWithValue("PhoneNumber", this.PhoneNumber);
            cmd.Parameters.AddWithValue("Major", this.Major);
            cmd.ExecuteScalar();
        }

        public Student(string name, string mail, string number, string major)
        {
            this.FullName = name;
            this.Email = mail;
            this.PhoneNumber = number;
            this.Major = major;
        }
    }
}
