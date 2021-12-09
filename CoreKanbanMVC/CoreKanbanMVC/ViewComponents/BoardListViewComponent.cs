using CoreKanbanMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreKanbanMVC.ViewComponents
{
    public class BoardListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var task = Task.Run(() => BoardService.ReadAllBoards());

            var boards = await task;

            return View("_BoardList", boards);
        }
    }
}
