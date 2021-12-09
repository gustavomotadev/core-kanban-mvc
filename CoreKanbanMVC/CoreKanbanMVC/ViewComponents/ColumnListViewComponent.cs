using CoreKanbanMVC.Models;
using CoreKanbanMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreKanbanMVC.ViewComponents
{
    public class ColumnListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int boardId)
        {
            var task = Task.Run(() => ColumnService.ReadColumnsInBoard(boardId));
            
            var columns = await task;
            
            return View("_ColumnList", columns);
        }
    }
}
