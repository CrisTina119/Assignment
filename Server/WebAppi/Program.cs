using FileRepositories;
using RepositoryContracts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddControllers();//CONTROLLERS

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPostRepository, PostInFileRepository>();
builder.Services.AddScoped<IUserRepository, UserInFileRepository>();
builder.Services.AddScoped<ICommentRepository, CommentInFileRepository>();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();//CONTROLLERS

Console.WriteLine("API is running");
app.Run();
