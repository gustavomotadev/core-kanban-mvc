using CoreKanbanMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreKanbanMVC.ViewComponents
{
    public class BoardViewComponent : ViewComponent
    {
        private readonly IBoardService _boardService;

        public BoardViewComponent(IBoardService boardService)
        {
            _boardService = boardService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var task = Task.Run(() => _boardService.ReadBoard(id));

            var board = await task;

            return View("_Board", board);
        }
    }
}
