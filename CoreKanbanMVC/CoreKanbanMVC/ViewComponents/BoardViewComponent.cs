using CoreKanbanMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreKanbanMVC.ViewComponents
{
    public class BoardViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var task = Task.Run(() => BoardService.ReadBoard(id));

            var board = await task;

            return View("_Board", board);
        }
    }
}
