using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShiftApp.Database
{
    public static class DBHelper
    {
        private static string connectionString = "Server=DESKTOP-3SD4HVT\\SQLEXPRESS;Database=eShiftDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
