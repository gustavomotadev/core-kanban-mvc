using Microsoft.AspNetCore.Mvc;
using CoreKanbanMVC.Services.Interfaces;

namespace CoreKanbanMVC.Controllers
{
    public class ColumnController : Controller
    {
        [HttpPost]
        public ActionResult CreateColumn(int boardId, string title,
            [FromServices] IColumnService columnService)
        {
            var id = columnService.CreateColumn(boardId, title);

            if (id != null) return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            else return RedirectToAction("Index", "Board");
        }

        [HttpPost]
        public ActionResult DeleteColumn(int id,
            [FromServices] IColumnService columnService)
        {
            var boardId = columnService.ReadColumn(id)?.BoardId;
            var affected = columnService.DeleteColumn(id);

            if (boardId != null && affected > 0) return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            else return RedirectToAction("Index", "Board");
        }

        [HttpPost]
        public ActionResult UpdateColumn(int id, string title,
            [FromServices] IColumnService columnService)
        {
            var boardId = columnService.ReadColumn(id)?.BoardId;
            var affected = columnService.UpdateColumn(id, title);

            if (boardId != null && affected > 0) return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            else return RedirectToAction("Index", "Board");
        }
    }
}