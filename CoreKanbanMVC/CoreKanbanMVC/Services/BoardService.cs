using CoreKanbanMVC.DAL;
using CoreKanbanMVC.Models;

namespace CoreKanbanMVC.Services
{
    public class BoardService
    {
        public static int DeleteBoard(int id)
        {
            return BoardRepository.DeleteBoard(id);
        }

        public static int UpdateBoard(int id, string title)
        {
            return BoardRepository.UpdateBoard(id, title);
        }

        public static int? CreateBoard(string title)
        {
            return BoardRepository.CreateBoard(title);
        }

        public static Board ReadBoard(int id)
        {
            var boardDB = BoardRepository.ReadBoard(id);

            return new Board() { Id = boardDB.Id, Title = boardDB.Title };
        }

        public static List<Board> ReadAllBoards()
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