using CleanArch.IoC.Extensions;
using CleanArch.Application.Extensions;
using CleanArch.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddApplicationLayer();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCorsPolicy();

var app = builder.Build();

var scope = app.Services.CreateScope();
await scope.CreateDatabaseAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
