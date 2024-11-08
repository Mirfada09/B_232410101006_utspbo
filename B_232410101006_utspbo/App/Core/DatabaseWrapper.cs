
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.App.Core
{
    internal class DatabaseWrapper
    {
        private static readonly string DB_HOST = "localhost";
        private static readonly string DB_DATABASE = "Login";
        private static readonly string DB_USERNAME = "postgres";
        private static readonly string DB_PASSWORD = "yoana1605";
        private static readonly string DB_PORT = "5432";

        private static NpgsqlConnection connection;
        private static NpgsqlCommand command;

 
            public static void openConnection()
            {
                connection = new NpgsqlConnection($"Host={DB_HOST};Username={DB_USERNAME};Password={DB_PASSWORD};Database={DB_DATABASE};Port={DB_PORT}");
                connection.Open();
                command = new NpgsqlCommand();
                command.Connection = connection;
            }

            public static void closeConnection()
            {
                connection.Close();
                command.Parameters.Clear();
            }

            public static DataTable queryExecutor(string query, NpgsqlParameter[] parameters = null)
            {
                try
                {
                    openConnection();
                    DataTable dataTable = new DataTable();
                    command.CommandText = query;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                        command.Prepare();
                    }
                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                    closeConnection();
                    return dataTable;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            public static long commandExecutor(string query, NpgsqlParameter[] parameters = null)
            {
                try
                {
                    openConnection();
                    command.CommandText = query;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.Prepare();

                    // Use ExecuteScalar to retrieve a single value (like a count)
                    long result = (long)command.ExecuteScalar();

                    command.Parameters.Clear();
                    closeConnection();
                    return result;
                }
                catch (Exception e)
                {
                    closeConnection(); // Ensure the connection is closed even if an error occurs
                    throw new Exception(e.Message);
                }
            }


        }
    }




}
}


