using CoreKanbanMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreKanbanMVC.ViewComponents
{
    public class NoteListViewComponent : ViewComponent
    {
        private readonly INoteService _noteService;

        public NoteListViewComponent(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int columnId)
        {
            var task = Task.Run(() => _noteService.ReadNotesInColumn(columnId));

            var notes = await task;

            return View("_NoteList", notes);
        }
    }
}
