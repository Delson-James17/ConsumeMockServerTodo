using ConsumeMockServerTodo.Data;
using ConsumeMockServerTodo.Models;
using ConsumeMockServerTodo.Repository;
using ConsumeMockServerTodo.Repository.RestApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CFTDbContext>();
builder.Services.AddSingleton<ICFTRepository, CFTRestRepository>();

builder.Services.AddScoped<CFTDbContext, CFTDbContext>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
