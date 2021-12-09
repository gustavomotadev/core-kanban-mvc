using CoreKanbanMVC.Repository.Interfaces;

namespace CoreKanbanMVC.Repository
{
    public class BoardRepository : IBoardRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        public BoardRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public int? CreateBoard(string title)
        {
            string insertQuery = $"INSERT INTO [dbo].[Board] ([Title]) OUTPUT Inserted.Id VALUES ('{title}')";

            return (int?) _databaseHelper.ExecuteScalarQuery(insertQuery);
        }

        public int UpdateBoard(int id, string title)
        {
            string updateQuery = $"UPDATE [dbo].[Board] SET [Title] = '{title}' WHERE Id = {id} SELECT @@ROWCOUNT";

            var result = _databaseHelper.ExecuteScalarQuery(updateQuery);

            return (result == null) ? 0 : (int) result;
        }

        public int DeleteBoard(int id)
        {
            string deleteQuery = $"DELETE FROM [dbo].[Board] WHERE Id = {id} SELECT @@ROWCOUNT";

            var result = _databaseHelper.ExecuteScalarQuery(deleteQuery);

            return (result == null) ? 0 : (int)result;
        }

        public dynamic ReadBoard(int id)
        {
            string readQuery = $"SELECT * FROM [dbo].[Board] WHERE Id = {id}";

            var dataReader = _databaseHelper.ExecuteReaderQuery(readQuery);

            dynamic result;

            if (dataReader.HasRows)
            {
                dataReader.Read();
                result = new {Id = Convert.ToInt32(dataReader["Id"]),
                    Title = dataReader["Title"].ToString()};
            }
            else result = null;

            dataReader.Dispose();

            return result;
        }

        public List<dynamic> ReadAllBoards()
        {
            string readQuery = $"SELECT * FROM [dbo].[Board]";

            var dataReader = _databaseHelper.ExecuteReaderQuery(readQuery);

            var result = new List<dynamic>();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.Add(new
                    {
                        Id = Convert.ToInt32(dataReader["Id"]),
                        Title = dataReader["Title"].ToString()
                    });
                }
            }

            dataReader.Dispose();

            return result;
        }
    }
}