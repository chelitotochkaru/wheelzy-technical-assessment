using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Wheelzy.API.Configuration;
using Wheelzy.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .RegisterServices()
    .AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Wheelzy API"
        });
    });

// Database configuration
builder.Services.AddDatabase(builder.Configuration.GetConnectionString("Default") ?? throw new ArgumentException("The connection string 'Default' has not been configurated."));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Set up EF Migration
app.UseDatabaseMigration(app.Services, app.Environment);

app.UseHttpsRedirection();

app
    .MapGet("/orders", async ([FromServices]IOrdersService ordersService) =>
    {
        return Results.Ok(await ordersService.GetOrders());
    })
    .WithName("GetOrders");

app.Run();
