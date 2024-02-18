using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolManagement.Models;
using SchoolManagement.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FgfgContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("con"));

});
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
