using CoreKanbanMVC.Models;

namespace CoreKanbanMVC.Services.Interfaces
{
    public interface IBoardService
    {
        public int DeleteBoard(int id);
        public int UpdateBoard(int id, string title);
        public int? CreateBoard(string title);
        public Board ReadBoard(int id);
        public List<Board> ReadAllBoards();
    }
}
