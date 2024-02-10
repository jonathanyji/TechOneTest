/*
    Program.cs is where the application starts.
    Startup.cs is where lot of the configuration happens.
    The idea for this separation is based on SOLID principles' first principle- SRP (Single Responsibility Principle)
    Ref: https://stackoverflow.com/a/64673991
 */

using TechOneTest;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
Startup startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services); // This adds services by calling the configuration services in Startup class

var app = builder.Build();

startup.Configure(app, app.Environment); // Configure the HTTP request pipeline.

app.Run();
