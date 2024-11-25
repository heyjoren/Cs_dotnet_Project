using ASPNET.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();  //build de router

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IRepo, Mock>();      //1 implementatie in hele app en linken/mappen tussen IRepo en data

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();      //van http naar https    //mag comment worden


app.UseAuthorization();      //gebruik van tokers
app.MapControllers();        //build de routes in de router

app.Run();
