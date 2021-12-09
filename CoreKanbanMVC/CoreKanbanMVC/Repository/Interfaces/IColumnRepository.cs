namespace CoreKanbanMVC.Repository.Interfaces
{
    public interface IColumnRepository
    {
        public int? CreateColumn(string title, int boardId);
        public int UpdateColumn(int id, string title);
        public int DeleteColumn(int id);
        public dynamic ReadColumn(int id);
        public List<dynamic> ReadAllColumns();
        public List<dynamic> ReadColumnsInBoard(int boardId);
    }
}
