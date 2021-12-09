using Microsoft.AspNetCore.Mvc;
using CoreKanbanMVC.Services.Interfaces;

namespace CoreKanbanMVC.Controllers
{
    public class NoteController : Controller
    {
        [HttpPost]
        public ActionResult CreateNote(int columnId, string title, string text,
            [FromServices] IColumnService columnService,
            [FromServices] INoteService noteService)
        {
            var id = noteService.CreateNote(columnId, title, text);
            var boardId = columnService.ReadColumn(columnId)?.BoardId;

            if (id != null && boardId != null) return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            else return RedirectToAction("Index", "Board");
        }

        [HttpPost]
        public ActionResult DeleteNote(int id,
            [FromServices] IColumnService columnService, 
            [FromServices] INoteService noteService)
        {
            var columnId = noteService.ReadNote(id)?.ColumnId;
            var boardId = (columnId != null) ? columnService.ReadColumn((int) columnId)?.BoardId : null;
            var affected = noteService.DeleteNote(id);

            if (boardId != null && affected > 0) return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            else return RedirectToAction("Index", "Board");
        }

        [HttpPost]
        public ActionResult UpdateNote(int id, string title, string text,
            [FromServices] IColumnService columnService, 
            [FromServices] INoteService noteService)
        {
            var columnId = noteService.ReadNote(id)?.ColumnId;
            var boardId = (columnId != null) ? columnService.ReadColumn((int)columnId)?.BoardId : null;
            var affected = noteService.UpdateNote(id, title, text);

            if (boardId != null && affected > 0) return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            else return RedirectToAction("Index", "Board");
        }
    }
}