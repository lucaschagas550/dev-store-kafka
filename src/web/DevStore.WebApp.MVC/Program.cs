using DevStore.WebApp.MVC.Configuration;
using Microsoft.AspNetCore.Builder;
using NetDevPack.OpenTelemetry.Otlp;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSerilog(new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger());

builder.Services.AddDevPackTracingOtlp(builder.Environment.ApplicationName);

builder.Services.AddIdentityConfiguration();

builder.Services.AddMvcConfiguration(builder.Configuration);

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.UseMvcConfiguration();

await app.RunAsync();