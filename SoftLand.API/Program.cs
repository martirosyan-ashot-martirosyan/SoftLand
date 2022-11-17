using Microsoft.EntityFrameworkCore;
using SoftLand.API.Handler;
using SoftLand.API.Handler.Interface;
using SoftLand.API.Mapper;
using SoftLand.API.Mapper.Interface;
using SoftLand.API.Validator;
using SoftLand.API.Validator.Interface;
using SoftLand.Application.Interface.Dao;
using SoftLand.Application.Service;
using SoftLand.Application.Service.Interface;
using SoftLand.Domain.Mapper;
using SoftLand.Domain.Mapper.Interface;
using SoftLand.Persistence.Context;
using SoftLand.Persistence.Dao;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ShirtDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddTransient<IDbShirtDataDtoMapper, DbShirtDataDtoMapper>();
builder.Services.AddTransient<IShirtRepository, ShirtRepository>();
builder.Services.AddTransient<IShirtService, ShirtService>();
builder.Services.AddTransient<IShirtRequestValidator, ShirtRequestValidator>();
builder.Services.AddTransient<IShirtGetRequestMapper, ShirtGetRequestMapper>();
builder.Services.AddTransient<IShirtAddRequestMapper, ShirtAddRequestMapper>();
builder.Services.AddTransient<IShirtResponseMapper, ShirtResponseMapper>();
builder.Services.AddTransient<IShirtRequestHandler, ShirtRequestHandler>();

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
