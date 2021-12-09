using CoreKanbanMVC.Models;
using CoreKanbanMVC.Repository.Interfaces;
using CoreKanbanMVC.Services.Interfaces;

namespace CoreKanbanMVC.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public int DeleteNote(int id)
        {
            return _noteRepository.DeleteNote(id);
        }

        public int UpdateNote(int id, string title, string text)
        {
            return _noteRepository.UpdateNote(id, title, text);
        }

        public int? CreateNote(int columnId, string title, string text)
        {
            return _noteRepository.CreateNote(title, text, columnId);
        }

        public Note ReadNote(int id)
        {
            var noteDB = _noteRepository.ReadNote(id);

            return new Note() { Id = noteDB.Id, Title = noteDB.Title, Text = noteDB.Text, ColumnId = noteDB.ColumnId };
        }

        public List<Note> ReadAllNotes()
        {
            var notesDB = _noteRepository.ReadAllNotes();
            var notes = new List<Note>();

            foreach (var noteDB in notesDB)
            {
                notes.Add(new Note() { Id = noteDB.Id, Title = noteDB.Title, Text = noteDB.Text, ColumnId = noteDB.ColumnId });
            }

            return notes;
        }

        public List<Note> ReadNotesInColumn(int columnId)
        {
            var notesDB = _noteRepository.ReadNotesInColumn(columnId);
            var notes = new List<Note>();

            foreach (var noteDB in notesDB)
            {
                notes.Add(new Note() { Id = noteDB.Id, Title = noteDB.Title, Text = noteDB.Text, ColumnId = noteDB.ColumnId });
            }

            return notes;
        }
    }
}