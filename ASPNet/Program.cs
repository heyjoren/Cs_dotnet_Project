var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();  //build de router

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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
