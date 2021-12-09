using CoreKanbanMVC.Models;
using CoreKanbanMVC.Repository.Interfaces;
using CoreKanbanMVC.Services.Interfaces;

namespace CoreKanbanMVC.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;

        public BoardService(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public int DeleteBoard(int id)
        {
            return _boardRepository.DeleteBoard(id);
        }

        public int UpdateBoard(int id, string title)
        {
            return _boardRepository.UpdateBoard(id, title);
        }

        public int? CreateBoard(string title)
        {
            return _boardRepository.CreateBoard(title);
        }

        public Board ReadBoard(int id)
        {
            var boardDB = _boardRepository.ReadBoard(id);

            return new Board() { Id = boardDB.Id, Title = boardDB.Title };
        }

        public List<Board> ReadAllBoards()
        {
            var boardsDB = _boardRepository.ReadAllBoards();
            var boards = new List<Board>();

            foreach (var boardDB in boardsDB)
            {
                boards.Add(new Board() { Id = boardDB.Id, Title = boardDB.Title });
            }

            return boards;
        }
    }
}