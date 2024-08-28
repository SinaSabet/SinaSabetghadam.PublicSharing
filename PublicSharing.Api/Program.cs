using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Prometheus;
using PublicSharing.Api;
using PublicSharing.Api.ExceptionHandler;
using PublicSharing.Application;
using PublicSharing.Infrastructure;
using PublicSharing.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddInfrastructurePersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.ConfigureCors();
builder.Services.AddEndpoints();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddOpenTelemetry();
builder.Services.AddProblemDetails();
var app = builder.Build();


app.UseExceptionHandler();
app.UseCors("AllowOrigin");

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMetricServer();
app.Run();

