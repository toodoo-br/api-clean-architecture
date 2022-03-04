using br.com.toodoo.api.Mappers;
using br.com.toodoo.core.Interfaces.Infrastructure;
using br.com.toodoo.core.Interfaces.Service;
using br.com.toodoo.infrastructure.Database.Context;
using br.com.toodoo.infrastructure.Repositories;
using br.com.toodoo.service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// AddAsync services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(DomainToModel));

builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<IFieldService, FieldService>();

builder.Services.AddScoped<IFieldRepository, FieldRepository>();
builder.Services.AddScoped<IFormRepository, FormRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("dbTest"));

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