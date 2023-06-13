using Microsoft.EntityFrameworkCore;  // Include Entity Framework Core for data access
using Asp.Net_Core_Mod_2.Data;  // Include application data-related classes
using Microsoft.Extensions.Configuration;  // Include classes for application configuration

// Configure and create the application
var builder = WebApplication.CreateBuilder(args);
// Retrieve the configuration that the builder uses
var configuration = builder.Configuration;

// Add services for controllers to the DI container
builder.Services.AddControllers();  
// Add and configure database context for DI
builder.Services.AddDbContext<ContactsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();  // Add services for API explorer

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Use developer exception page in development mode
}

app.UseHttpsRedirection();  // Use HTTPS redirection
app.UseAuthorization();  // Use authorization

app.MapControllers();  // Map attribute routed controllers

app.Run();  // Run the application
public partial class Program { }
