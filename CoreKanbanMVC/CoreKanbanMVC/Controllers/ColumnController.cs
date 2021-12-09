using Microsoft.AspNetCore.Mvc;
using CoreKanbanMVC.Services;

namespace CoreKanbanMVC.Controllers
{
    public class ColumnController : Controller
    {
        [HttpPost]
        public ActionResult CreateColumn(int boardId, string title)
        {
            var id = ColumnService.CreateColumn(boardId, title);

            if (id != null) return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            else return RedirectToAction("Index", "Board");
        }

        [HttpPost]
        public ActionResult DeleteColumn(int id)
        {
            var column = ColumnService.ReadColumn(id);

            if (column != null)
            {
                var boardId = column.BoardId;
                ColumnService.DeleteColumn(id);

                return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            }
            else return RedirectToAction("Index", "Board");
        }

        [HttpPost]
        public ActionResult UpdateColumn(int id, string title)
        {
            var column = ColumnService.ReadColumn(id);

            if (column != null)
            {
                var boardId = column.BoardId;
                ColumnService.UpdateColumn(id, title);
                return RedirectToAction("DisplayBoard", "Board", new { id = boardId });
            }
            else return RedirectToAction("Index", "Board");
        }
    }
}