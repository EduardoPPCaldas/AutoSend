using AutoSend.Application;
using AutoSend.Domain;
using AutoSend.Infrastructure;
using AutoSend.WebApi;
using AutoSend.WebApi.Endpoints;
using AutoSend.WebApi.Options;

using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.Local.json", true);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddAuthentication()
    .AddGoogle("google", opt =>
    {
        var googleOptions = builder.Configuration
            .GetSection(GoogleOptions.Configuration)
            .Get<GoogleOptions>() ?? throw new InvalidProgramException("Google options configuration cannot be null");

        opt.ClientId = googleOptions.ClientId;
        opt.ClientSecret = googleOptions.ClientSecret;
        opt.SignInScheme = IdentityConstants.ExternalScheme;
    });

builder.Services
    .AddWebApiServices()
    .AddInfrastructureServices()
    .AddApplicationServices()
    .AddDomainServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddWeatherForecastEndpoints();

app.UseHttpsRedirection();

app.Run();
