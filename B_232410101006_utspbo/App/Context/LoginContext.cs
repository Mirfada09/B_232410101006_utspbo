using B_232410101006_utspbo.App.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.App.Context
{
    internal class Login : DatabaseWrapper 
    {
        private static string table = "admin",

    }
        public static long login(string username, string password)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {table} WHERE username = @username AND password = @password";
            NpgsqlParameter[] parameters =
{
            new NpgsqlParameter("username", NpgsqlDbType.Varchar) { Value = username },
            new NpgsqlParameter("password", NpgsqlDbType.Varchar) { Value = password }
        };

            long result = commandExecutor(query, parameters);
            return result > 0 ? 1 : 0; 
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
            return 0;
        }
    }



}

