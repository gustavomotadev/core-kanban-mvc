using Microsoft.AspNetCore.Mvc;
using CoreKanbanMVC.Services;

namespace CoreKanbanMVC.Controllers
{
    public class BoardController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayBoard(int id)
        {
            var board = BoardService.ReadBoard(id);

            return View(board);
        }

        [HttpPost]
        public ActionResult DeleteBoard(int id)
        {
            var affected = BoardService.DeleteBoard(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateBoard(int id, string title)
        {
            var affected = BoardService.UpdateBoard(id, title);

            if (affected > 0) return RedirectToAction("DisplayBoard", new {id});
            else return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateBoard(string title)
        {
            var id = BoardService.CreateBoard(title);

            if (id != null) return RedirectToAction("DisplayBoard", new { id });
            else return RedirectToAction("Index");
        }
    }
}