using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using TaskManagerMinimalAPI.Entities;
using TaskManagerMinimalAPI.Repositories;
using TaskManagerMinimalAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITasksRepository, TasksRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));

app.MapGet("/tasks", (ITasksRepository items) =>
{
    return items.GetAll();
});

app.MapGet("/tasks/{id}", (ITasksRepository items, Guid id) =>
{
    var result = items.GetById(id);
    return result != null ? Results.Ok(result) : Results.NotFound();
});

app.MapPut("/tasks/{id}", (ITasksRepository items, Guid id, TaskEntity item) =>
{
    if (items.GetById(id) == null)
    {
        return Results.NotFound();
    }

    items.Update(item);
    return Results.Ok(item);
});

app.MapDelete("/tasks/{id}", (ITasksRepository items, Guid id) =>
{
    if (items.GetById(id) == null)
    {
        return Results.NotFound();
    }

    items.Delete(id);
    return Results.NoContent();
});

app.Run();
