using ConcertTicketManagementSystem.Infrastructure.DbPersistence;
using ConcertTicketManagementSystem.Repositories.EventRepo;
using ConcertTicketManagementSystem.Repositories.TicketRepo;
using ConcertTicketManagementSystem.Services.EventServices;
using ConcertTicketManagementSystem.Services.TicketServices;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddControllers();

// Dependency Injection registrations  
// Registering EventService and TicketService for handling business logic  
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ITicketService, TicketService>();

// Registering repositories for data access layer  
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
// Adding Swagger for API documentation and testing  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Database Connection  
// Setting up Entity Framework Core with SQL Server using connection string from configuration  
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development environment  
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable detailed error pages in development environment  
app.UseDeveloperExceptionPage();

// Enforce HTTPS for secure communication  
app.UseHttpsRedirection();

// Enable authorization middleware  
app.UseAuthorization();

// Map controller routes to handle incoming HTTP requests  
app.MapControllers();

// Run the application  
app.Run();