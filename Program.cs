using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
