using MauiApi.Data;
using MauiApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/users", async (AppDbContext context) =>
{
    var users = await context.Users.ToListAsync();

    return Results.Ok(users);
});

app.MapPost("api/users", async (AppDbContext context, User user) =>
{ 
    await context.Users.AddAsync(user); 
    await context.SaveChangesAsync();

    return Results.Created($"api/users/{user.Id}", user);
});

app.MapPut("api/users/{id}", async (AppDbContext context, int id, User user) =>
{
    var userModel = await context.Users.FirstOrDefaultAsync(x => x.Id == id);   

    if(userModel == null)
    {
        return Results.NotFound();
    }
    else
    {
        userModel.Name = user.Name; 
        userModel.Surname = user.Surname;

        await context.SaveChangesAsync();

        return Results.Ok(userModel);
    }

    return Results.NoContent();
});

app.MapDelete("api/users/{id}", async (AppDbContext context, int id) =>
{
    var userModel = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

    if (userModel == null)
    {
        return Results.NotFound();
    }
    else
    {
        context.Users.Remove(userModel);    

        await context.SaveChangesAsync();

        return Results.NoContent();
    }
});

app.Run();

