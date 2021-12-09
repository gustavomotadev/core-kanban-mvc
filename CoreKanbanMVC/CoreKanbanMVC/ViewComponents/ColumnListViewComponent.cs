using CoreKanbanMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreKanbanMVC.ViewComponents
{
    public class ColumnListViewComponent : ViewComponent
    {
        private readonly IColumnService _columnService;

        public ColumnListViewComponent(IColumnService columnService)
        {
            _columnService = columnService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int boardId)
        {
            var task = Task.Run(() => _columnService.ReadColumnsInBoard(boardId));
            
            var columns = await task;
            
            return View("_ColumnList", columns);
        }
    }
}
