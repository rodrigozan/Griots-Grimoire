using System;
using System.Text; 
using MongoDB.Driver;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

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

var key = Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:Key"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
