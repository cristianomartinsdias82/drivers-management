using Drivers.Api.Endpoints;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Drivers.Infrastructure.DataAccess.Configuration;

var builder = WebApplication.CreateBuilder(args);

var dbConnString = builder.Configuration["ConnectionStrings:DriversManagement"]!;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
            .AddHealthChecks()
            .AddSqlServer(dbConnString,
                    healthQuery: "SELECT 1",
                    name: "Db health check",
                    failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy,
                    tags: ["sql", "sqlserver", "healthchecks"]);
builder.Services
            .AddDataAccess(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapDriversEndpoints(builder.Configuration);

app.Run();
