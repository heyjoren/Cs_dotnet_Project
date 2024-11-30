using ASPNET.Contexts;
using ASPNET.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();  //build de router

builder.Services.AddScoped<IRepo, MySQLRepo>();      //1 implementatie in hele app en linken/mappen tussen IRepo en data         naar sql

string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];    // gaat in de appsettings kijken

builder.Services.AddDbContext<ItemContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());        //activeer de automapper

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});


builder.WebHost.UseUrls("http://*:80");


var app = builder.Build();

app.UseAuthorization();      //gebruik van tokers
app.MapControllers();        //build de routes in de router

app.Run();
