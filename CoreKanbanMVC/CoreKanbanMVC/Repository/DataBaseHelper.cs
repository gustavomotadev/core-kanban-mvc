using CoreKanbanMVC.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CoreKanbanMVC.Repository
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public object ExecuteScalarQuery(string query)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            var result = command.ExecuteScalar();

            command.Dispose();
            connection.Dispose();

            return result;
        }

        public SqlDataReader ExecuteReaderQuery(string query)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            var result = command.ExecuteReader(CommandBehavior.CloseConnection); //connection will be closed on closing SqlDataReader

            command.Dispose();
            //connection.Dispose(); //connection will be closed on closing SqlDataReader

            return result;
        }
    }
}