using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IMongoClient>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
});

builder.Services.AddScoped<IMongoDatabase>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var mongoClient = provider.GetRequiredService<IMongoClient>();
    return mongoClient.GetDatabase(configuration.GetSection("MongoDB:DatabaseName").Value);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
