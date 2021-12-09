using CoreKanbanMVC.DAL;
using CoreKanbanMVC.Models;

namespace CoreKanbanMVC.Services
{
    public class NoteService
    {
        public static int DeleteNote(int id)
        {
            return NoteRepository.DeleteNote(id);
        }

        public static int UpdateNote(int id, string title, string text)
        {
            return NoteRepository.UpdateNote(id, title, text);
        }

        public static int? CreateNote(int columnId, string title, string text)
        {
            return NoteRepository.CreateNote(title, text, columnId);
        }

        public static Note ReadNote(int id)
        {
            var noteDB = NoteRepository.ReadNote(id);

            return new Note() { Id = noteDB.Id, Title = noteDB.Title, Text = noteDB.Text, ColumnId = noteDB.ColumnId };
        }

        public static List<Note> ReadAllNotes()
        {
            var notesDB = NoteRepository.ReadAllNotes();
            var notes = new List<Note>();

            foreach (var noteDB in notesDB)
            {
                notes.Add(new Note() { Id = noteDB.Id, Title = noteDB.Title, Text = noteDB.Text, ColumnId = noteDB.ColumnId });
            }

            return notes;
        }

        public static List<Note> ReadNotesInColumn(int columnId)
        {
            var notesDB = NoteRepository.ReadNotesInColumn(columnId);
            var notes = new List<Note>();

            foreach (var noteDB in notesDB)
            {
                notes.Add(new Note() { Id = noteDB.Id, Title = noteDB.Title, Text = noteDB.Text, ColumnId = noteDB.ColumnId });
            }

            return notes;
        }
    }
}