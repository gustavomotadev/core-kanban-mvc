using CoreKanbanMVC.Repository.Interfaces;

namespace CoreKanbanMVC.Repository
{
    public class ColumnRepository : IColumnRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        public ColumnRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public int? CreateColumn(string title, int boardId)
        {
            string insertQuery = $"INSERT INTO [dbo].[Column] ([Title],[BoardId]) OUTPUT Inserted.Id VALUES ('{title}',{boardId})";

            return (int?) _databaseHelper.ExecuteScalarQuery(insertQuery);
        }

        public int UpdateColumn(int id, string title)
        {
            string updateQuery = $"UPDATE [dbo].[Column] SET [Title] = '{title}' WHERE Id = {id} SELECT @@ROWCOUNT";

            var result = _databaseHelper.ExecuteScalarQuery(updateQuery);

            return (result == null) ? 0 : (int)result;
        }

        public int DeleteColumn(int id)
        {
            string deleteQuery = $"DELETE FROM [dbo].[Column] WHERE Id = {id} SELECT @@ROWCOUNT";

            var result = _databaseHelper.ExecuteScalarQuery(deleteQuery);

            return (result == null) ? 0 : (int)result;
        }

        public dynamic ReadColumn(int id)
        {
            string readQuery = $"SELECT * FROM [dbo].[Column] WHERE Id = {id}";

            var dataReader = _databaseHelper.ExecuteReaderQuery(readQuery);

            dynamic result;

            if (dataReader.HasRows)
            {
                dataReader.Read();
                result = new
                {
                    Id = Convert.ToInt32(dataReader["Id"]),
                    Title = dataReader["Title"].ToString(),
                    BoardId = Convert.ToInt32(dataReader["BoardId"])
                };
            }
            else result = null;

            dataReader.Dispose();

            return result;
        }

        public List<dynamic> ReadAllColumns()
        {
            string readQuery = $"SELECT * FROM [dbo].[Column]";

            var dataReader = _databaseHelper.ExecuteReaderQuery(readQuery);

            var result = new List<dynamic>();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.Add(new
                    {
                        Id = Convert.ToInt32(dataReader["Id"]),
                        Title = dataReader["Title"].ToString(),
                        BoardId = Convert.ToInt32(dataReader["BoardId"])
                    });
                }
            }

            dataReader.Dispose();

            return result;
        }

        public List<dynamic> ReadColumnsInBoard(int boardId)
        {
            string readQuery = $"SELECT * FROM [dbo].[Column] WHERE BoardId = {boardId}";

            var dataReader = _databaseHelper.ExecuteReaderQuery(readQuery);

            var result = new List<dynamic>();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.Add(new
                    {
                        Id = Convert.ToInt32(dataReader["Id"]),
                        Title = dataReader["Title"].ToString(),
                        BoardId = Convert.ToInt32(dataReader["BoardId"])
                    });
                }
            }

            dataReader.Dispose();

            return result;
        }
    }
}