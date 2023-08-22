using InventoryControl.Api.Data;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InventoryControl.Api.Mapping;
using InventoryControl.Api.Services.IServices;
using InventoryControl.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ICDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryControlDB"));
});

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
