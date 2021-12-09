using CoreKanbanMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreKanbanMVC.ViewComponents
{
    public class BoardListViewComponent : ViewComponent
    {
        private readonly IBoardService _boardService;

        public BoardListViewComponent(IBoardService boardService)
        {
            _boardService = boardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var task = Task.Run(() => _boardService.ReadAllBoards());

            var boards = await task;

            return View("_BoardList", boards);
        }
    }
}
