using CoreKanbanMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreKanbanMVC.ViewComponents
{
    public class NoteListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int columnId)
        {
            var task = Task.Run(() => NoteService.ReadNotesInColumn(columnId));

            var notes = await task;

            return View("_NoteList", notes);
        }
    }
}
