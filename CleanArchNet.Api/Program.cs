
using Microsoft.EntityFrameworkCore;

using CleanArchNet.Infrastructure;

using CleanArchNet.Domain.Interfaces;
using CleanArchNet.Infrastructure.Repositories;
using CleanArchNet.Application.Interfaces;
using CleanArchNet.Application.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conditional configuration based on the environment
if (builder.Environment.IsDevelopment())
{
    // Configure in-memory database for development
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite("Data Source=:memory:", b => b.MigrationsAssembly("CleanArchNet.Infrastructure")),
        ServiceLifetime.Singleton); // Ensure DbContext is singleton to maintain in-memory DB
    
    builder.Services.AddSingleton<ITodoRepository, TodoRepository>(); 
    builder.Services.AddSingleton<ITodoService, TodoService>(); // Register repository as singleton
}
else
{
    // Configure a persistent database for production
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<ITodoRepository, TodoRepository>();
    builder.Services.AddScoped<ITodoService, TodoService>(); // Scoped lifetime is typical for production
}

var app = builder.Build();

// Ensure the database is created and connection opened in development
if (app.Environment.IsDevelopment())
{
    var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.OpenConnection();
    dbContext.Database.EnsureCreated();

    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
