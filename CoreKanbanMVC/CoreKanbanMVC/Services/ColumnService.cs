using CoreKanbanMVC.DAL;
using CoreKanbanMVC.Models;
using CoreKanbanMVC.Services.Interfaces;

namespace CoreKanbanMVC.Services
{
    public class ColumnService : IColumnService
    {
        public int DeleteColumn(int id)
        {
            return ColumnRepository.DeleteColumn(id);
        }

        public int UpdateColumn(int id, string title)
        {
            return ColumnRepository.UpdateColumn(id, title);
        }

        public int? CreateColumn(int boardId, string title)
        {
            return ColumnRepository.CreateColumn(title, boardId);
        }

        public Column ReadColumn(int id)
        {
            var columnDB = ColumnRepository.ReadColumn(id);

            return new Column() { Id = columnDB.Id, Title = columnDB.Title, BoardId = columnDB.BoardId };
        }

        public List<Column> ReadAllColumns()
        {
            var columnsDB = ColumnRepository.ReadAllColumns();
            var columns = new List<Column>();

            foreach (var columnDB in columnsDB)
            {
                columns.Add(new Column() { Id = columnDB.Id, Title = columnDB.Title, BoardId = columnDB.BoardId });
            }

            return columns;
        }

        public List<Column> ReadColumnsInBoard(int boardId)
        {
            var columnsDB = ColumnRepository.ReadColumnsInBoard(boardId);
            var columns = new List<Column>();

            foreach (var columnDB in columnsDB)
            {
                columns.Add(new Column() { Id = columnDB.Id, Title = columnDB.Title, BoardId = columnDB.BoardId });
            }

            return columns;
        }
    }
}