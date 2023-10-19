using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Teniaco_SecondSenario_Api.Models.Context;
using System;
using Teniaco_SecondSenario_Api.Repositories.Interfaces;
using Teniaco_SecondSenario_Api.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TeniacoDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
 builder.Services.AddControllers()
                .AddFluentValidation(options =>
                {
                    // Validate child properties and root collection elements
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;
                    // Automatic registration of validators in assembly
                    options.RegisterValidatorsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
                });
builder.Services.AddAutoMapper(typeof(Program))
    ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
