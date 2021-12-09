using CoreKanbanMVC.Models;
using CoreKanbanMVC.Repository.Interfaces;
using CoreKanbanMVC.Services.Interfaces;

namespace CoreKanbanMVC.Services
{
    public class ColumnService : IColumnService
    {
        private readonly IColumnRepository _columnRepository;

        public ColumnService(IColumnRepository boardRepository)
        {
            _columnRepository = boardRepository;
        }

        public int DeleteColumn(int id)
        {
            return _columnRepository.DeleteColumn(id);
        }

        public int UpdateColumn(int id, string title)
        {
            return _columnRepository.UpdateColumn(id, title);
        }

        public int? CreateColumn(int boardId, string title)
        {
            return _columnRepository.CreateColumn(title, boardId);
        }

        public Column ReadColumn(int id)
        {
            var columnDB = _columnRepository.ReadColumn(id);

            return new Column() { Id = columnDB.Id, Title = columnDB.Title, BoardId = columnDB.BoardId };
        }

        public List<Column> ReadAllColumns()
        {
            var columnsDB = _columnRepository.ReadAllColumns();
            var columns = new List<Column>();

            foreach (var columnDB in columnsDB)
            {
                columns.Add(new Column() { Id = columnDB.Id, Title = columnDB.Title, BoardId = columnDB.BoardId });
            }

            return columns;
        }

        public List<Column> ReadColumnsInBoard(int boardId)
        {
            var columnsDB = _columnRepository.ReadColumnsInBoard(boardId);
            var columns = new List<Column>();

            foreach (var columnDB in columnsDB)
            {
                columns.Add(new Column() { Id = columnDB.Id, Title = columnDB.Title, BoardId = columnDB.BoardId });
            }

            return columns;
        }
    }
}