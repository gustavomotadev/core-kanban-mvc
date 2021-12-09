using CoreKanbanMVC.Models;

namespace CoreKanbanMVC.Services.Interfaces
{
    public interface IColumnService
    {
        public int DeleteColumn(int id);
        public int UpdateColumn(int id, string title);
        public int? CreateColumn(int boardId, string title);
        public Column ReadColumn(int id);
        public List<Column> ReadAllColumns();
        public List<Column> ReadColumnsInBoard(int boardId);
    }
}
