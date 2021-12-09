using CoreKanbanMVC.DAL;
using CoreKanbanMVC.Models;
using CoreKanbanMVC.Services.Interfaces;

namespace CoreKanbanMVC.Services
{
    public class BoardService : IBoardService
    {
        public int DeleteBoard(int id)
        {
            return BoardRepository.DeleteBoard(id);
        }

        public int UpdateBoard(int id, string title)
        {
            return BoardRepository.UpdateBoard(id, title);
        }

        public int? CreateBoard(string title)
        {
            return BoardRepository.CreateBoard(title);
        }

        public Board ReadBoard(int id)
        {
            var boardDB = BoardRepository.ReadBoard(id);

            return new Board() { Id = boardDB.Id, Title = boardDB.Title };
        }

        public List<Board> ReadAllBoards()
        {
            var boardsDB = BoardRepository.ReadAllBoards();
            var boards = new List<Board>();

            foreach (var boardDB in boardsDB)
            {
                boards.Add(new Board() { Id = boardDB.Id, Title = boardDB.Title });
            }

            return boards;
        }
    }
}