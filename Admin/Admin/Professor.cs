﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class Professor
    {
        public int Professor_ID { get; set; }
        public string Professor_Name { get; set; }
        public string Professor_Title { get; set; }
        // Contains professor ID
        // Contains professor Name
        // Contains professor Title

        static public void InsertProfessor(SqlConnection conn, Professor prof)
        {
            var _insert = "INSERT INTO PROFESSORS (Name, Title)" +
                "VALUES (@Name, @Title)";

            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("Name", prof.Professor_Name);
            cmd.Parameters.AddWithValue("Title", prof.Professor_Title);
            cmd.ExecuteScalar();
        }

        public Professor()
        {

        }
    }
}