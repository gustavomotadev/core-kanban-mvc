namespace CoreKanbanMVC.Repository.Interfaces
{
    public interface INoteRepository
    {
        public int? CreateNote(string title, string text, int columnId);
        public int UpdateNote(int id, string title, string text);
        public int DeleteNote(int id);
        public dynamic ReadNote(int id);
        public List<dynamic> ReadAllNotes();
        public List<dynamic> ReadNotesInColumn(int columnId);
    }
}
