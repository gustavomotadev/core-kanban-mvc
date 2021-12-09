using CoreKanbanMVC.Models;

namespace CoreKanbanMVC.Services.Interfaces
{
    public interface INoteService
    {
        public int DeleteNote(int id);
        public int UpdateNote(int id, string title, string text);
        public int? CreateNote(int columnId, string title, string text);
        public Note ReadNote(int id);
        public List<Note> ReadAllNotes();
        public List<Note> ReadNotesInColumn(int columnId);
    }
}
