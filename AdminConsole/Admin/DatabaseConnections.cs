﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    class DatabaseConnections
    {
        // Get the database location.
        protected const string CONNECTION_STRING =
@"Server=localhost\SQLEXPRESS;Database=University_Of_Proforma;Trusted_Connection=True;";
    }
}
