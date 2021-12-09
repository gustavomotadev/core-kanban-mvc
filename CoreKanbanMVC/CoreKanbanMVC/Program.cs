using CoreKanbanMVC.Services;
using CoreKanbanMVC.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IColumnService, ColumnService>();
builder.Services.AddScoped<INoteService, NoteService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Board}/{action=Index}/{id?}");

app.Run();
