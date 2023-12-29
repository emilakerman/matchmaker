using Microsoft.EntityFrameworkCore;
using Matchmaker.API.Data;
using Matchmaker.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("MatchmakerConnection")
        )
);
builder.Services.AddDbContext<Context>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// api call methods here

app.MapGet("/user", (Context context) => context.Users.ToList());

app.MapPost("/user", (Context context, string name, string profileText) =>
{
    User user = new User(name, profileText);
    context.Users.Add(user);
    context.SaveChanges();
});

app.MapPut("/like", (Context context, int userId, int likedId) =>
{
    User? user = context.Users.Find(userId);
    if (user == null){
        //return http 404
       return Results.NotFound();
        
    } else {
        user.Likes?.Add(likedId);
        context.SaveChanges();
        return Results.Ok();
    }
});

app.MapPut("/dislike", (Context context, int userId, int disLikedId) =>
{
    User? user = context.Users.Find(userId);
     if (user == null){
        return Results.NotFound();
     } else {
    user.Dislikes?.Add(disLikedId);
    context.SaveChanges();
    return Results.Ok();
     }
});

// Delete like
app.MapDelete("/like",(Context context, int userId, int likedId) =>
{
    User? user = context.Users.Find(userId);
    user?.Likes?.Remove(likedId);
    context.SaveChanges();
});

//funkar ej ännu!
// app.MapPost("/sendMessage", (Context context, string content, int senderUserId, int receiverUserId) =>
// {
//     Message message = new Message(content,senderUserId,receiverUserId);
//     context.Messages.Add(message);
//     context.SaveChanges();

//     return Results.Ok();
// });
// //funkar ej ännu!
// app.MapGet("/getMessages", (Context context, int userId) =>
// {
//     var messages = context.Messages
//         .Where(msg => msg.SenderId == userId || msg.RecieverId == userId)
//         .OrderBy(msg => msg.TimeStamp)
//         .ToList();

//     return Results.Ok();
// });


app.Run();

