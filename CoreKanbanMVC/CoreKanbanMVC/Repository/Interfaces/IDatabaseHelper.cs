using System.Data.SqlClient;

namespace CoreKanbanMVC.Repository.Interfaces
{
    public interface IDatabaseHelper
    {
        public object ExecuteScalarQuery(string query);
        public SqlDataReader ExecuteReaderQuery(string query);
    }
}
