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
            var column = columnService.ReadColumn(id);

            if (column != null)
            {
                var boardId = column.BoardId;
                columnService.DeleteColumn(id);

                return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            }
            else return RedirectToAction("Index", "Board");
        }

        [HttpPost]
        public ActionResult UpdateColumn(int id, string title,
            [FromServices] IColumnService columnService)
        {
            var column = columnService.ReadColumn(id);

            if (column != null)
            {
                var boardId = column.BoardId;
                columnService.UpdateColumn(id, title);
                return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            }
            else return RedirectToAction("Index", "Board");
        }
    }
}