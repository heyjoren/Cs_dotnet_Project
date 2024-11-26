using ASPNET.Contexts;
using ASPNET.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();  //build de router

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

builder.Services.AddScoped<IRepo, Mock>();      //1 implementatie in hele app en linken/mappen tussen IRepo en data    naar mock data test
// builder.Services.AddScoped<IRepo, MySQLRepo>();      //1 implementatie in hele app en linken/mappen tussen IRepo en data         naar sql

string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];    // gaat in de appsettings kijken

builder.Services.AddDbContext<ItemContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());        //activeer de automapper




var app = builder.Build();



// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.UseHttpsRedirection();      //van http naar https    //mag comment worden


app.UseAuthorization();      //gebruik van tokers
app.MapControllers();        //build de routes in de router

app.Run();
