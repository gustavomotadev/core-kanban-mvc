using Microsoft.AspNetCore.Mvc;
using CoreKanbanMVC.Services.Interfaces;

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
        public ActionResult DisplayBoard(int id, 
            [FromServices] IBoardService boardService)
        {
            var board = boardService.ReadBoard(id);

            return View(board);
        }

        [HttpPost]
        public ActionResult DeleteBoard(int id,
            [FromServices] IBoardService boardService)
        {
            var affected = boardService.DeleteBoard(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateBoard(int id, string title,
            [FromServices] IBoardService boardService)
        {
            var affected = boardService.UpdateBoard(id, title);

            if (affected > 0) return RedirectToAction("DisplayBoard", new {id});
            else return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateBoard(string title,
            [FromServices] IBoardService boardService)
        {
            var id = boardService.CreateBoard(title);

            if (id != null) return RedirectToAction("DisplayBoard", new { id });
            else return RedirectToAction("Index");
        }
    }
}