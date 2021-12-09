using Microsoft.AspNetCore.Mvc;
using CoreKanbanMVC.Services;

namespace CoreKanbanMVC.Controllers
{
    public class NoteController : Controller
    {
        [HttpPost]
        public ActionResult CreateNote(int columnId, string title, string text)
        {
            var id = NoteService.CreateNote(columnId, title, text);
            var boardId = ColumnService.ReadColumn(columnId)?.BoardId;

            if (id != null && boardId != null) return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            else return RedirectToAction("Index", "Board");
        }

        [HttpPost]
        public ActionResult DeleteNote(int id)
        {
            var columnId = NoteService.ReadNote(id)?.ColumnId;
            var boardId = (columnId != null) ? ColumnService.ReadColumn((int) columnId)?.BoardId : null;

            if (boardId != null)
            {
                NoteService.DeleteNote(id);
                return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            }
            else return RedirectToAction("Index", "Board");
        }

        [HttpPost]
        public ActionResult UpdateNote(int id, string title, string text)
        {
            var columnId = NoteService.ReadNote(id)?.ColumnId;
            var boardId = (columnId != null) ? ColumnService.ReadColumn((int)columnId)?.BoardId : null;

            if (boardId != null)
            {
                NoteService.UpdateNote(id, title, text);
                return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            }
            else return RedirectToAction("Index", "Board");
        }
    }
}