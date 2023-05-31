using SinbadProjectManagement.API.Configuration;
using SinbadProjectManagement.API.Extensions;
using SinbadProjectManagement.Application.Exceptions;
using SinbadProjectManagement.Application.Projects.Commands.Create;
using SinbadProjectManagement.Application.Repositores.Abstractions;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.ConfigureServices();

var app = builder.Build();
app.SeedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerConfiguration();
}
// if(!app.Environment.IsDevelopment())
// {
    app.UseExceptionHandler("/error");
//}

var allowedOrigins = new string[] {"http://localhost:4200",};

app.UseCors(c =>
{
    c
        //.WithOrigins(allowedOrigins)
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
