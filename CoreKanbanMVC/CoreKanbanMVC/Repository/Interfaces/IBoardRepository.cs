namespace CoreKanbanMVC.Repository.Interfaces
{
    public interface IBoardRepository
    {
        public int? CreateBoard(string title);
        public int UpdateBoard(int id, string title);
        public int DeleteBoard(int id);
        public dynamic ReadBoard(int id);
        public List<dynamic> ReadAllBoards();
    }
}
