using FluentValidation.AspNetCore;
using InventoryApp.Api.Infraestructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson()
    .AddFluentValidation(s =>
    {
        s.RegisterValidatorsFromAssemblyContaining<Program>();
        s.DisableDataAnnotationsValidation = true;
    });




builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<g5FtGnkAVWContext>(option =>
{
    option.UseMySql(builder.Configuration.GetConnectionString("DatabaseConnection"), ServerVersion.Parse("8.0.13-mysql"));
});

builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddHttpContextAccessor();



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
