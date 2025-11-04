using Microsoft.EntityFrameworkCore;
using MovieApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers(); // scans for any class that inherits from ControllerBase or Controller, has [ApiController] or [Route] attributes
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext (SQLite)
builder.Services.AddDbContext<MovieContext>(options =>  // contexts are registered with DI container from the controller constructor
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
