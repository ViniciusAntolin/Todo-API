using Todo.Data;
using Todo.Data.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<IAppDbContext, AppDbContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
