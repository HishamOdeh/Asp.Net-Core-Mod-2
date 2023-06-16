using Microsoft.EntityFrameworkCore;  // Include Entity Framework Core for data access
using Asp.Net_Core_Mod_2.Data;  // Include application data-related classes
using Microsoft.Extensions.Configuration;  // Include classes for application configuration
using RepoDb;
using BlazorApp_Mod__7.Service;

// Configure and create the application
var builder = WebApplication.CreateBuilder(args);
// Retrieve the configuration that the builder uses
var configuration = builder.Configuration;

// Add services for controllers to the DI container
builder.Services.AddControllers();  
// Add and configure database context for DI
builder.Services.AddDbContext<ContactsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();  // Add services for API explorer
//builder.Services.AddScoped<IContactService, ContactService>();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Use developer exception page in development mode
}

//This si for the RepoDB connection
RepoDb.GlobalConfiguration
    .Setup()
    .UseSqlServer();

app.UseHttpsRedirection();  // Use HTTPS redirection
app.UseAuthorization();  // Use authorization

app.MapControllers();  // Map attribute routed controllers

app.Run();  // Run the application


//do i really need this?
public partial class Program { }
