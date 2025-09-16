using System;
using Entities;
using RepositoryContracts;
using RepositoryContracts.Interfaces;


namespace InMemoryRepositories_;

public class CommentInMemoryRepository : ICommentRepository
{
    private readonly List<Comment> comments = [];
   
    public CommentInMemoryRepository()
    {
        // .GetAwaiter() blocks the async call since constructors cannot be async (ideally we should seed somewhere else, but this keeps things simple)
        SeedDataAsync().GetAwaiter();
    }
    public Task<Comment> AddAsync(Comment comment)
    {
        comment.Id = comments.Count != 0 ? comments.Max(u => u.Id) + 1 : 1;
        comments!.Add(comment);
        return Task.FromResult(comment);
    }

    public Task UpdateAsync(Comment comment)
    {
        Comment? existingComment = comments!.SingleOrDefault(c => c.Id == comment.Id);
        if (existingComment is null)
        {
            throw new InvalidOperationException(
                $"Comment with ID '{comment.Id}' not found");
        }

        comments!.Remove(existingComment);
        comments.Add(comment);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        Comment? commentToRemove = comments.SingleOrDefault(c => c.Id == id) ?? throw new InvalidOperationException($"Comment with ID '{id}' not found.");
        /* if (commentToRemove is null)
         {
             throw new InvalidOperationException($"Comment with ID '{id}' not found");
         }*/

        comments!.Remove(commentToRemove);
        return Task.CompletedTask;
    }

    public Task<Comment?> GetSingleAsync(int id)
    {
        Comment? comment = comments!.SingleOrDefault(c => c.Id == id) ?? throw new InvalidOperationException($"Comment with ID '{id}' not found.");
        return Task.FromResult(comment);
    }

    public IQueryable<Comment> GetManyAsync()
    {
       return comments.AsQueryable();
    }
        private async Task SeedDataAsync()
    {
        Comment comment1 = new()
        {
            Id = 1,
            Body = "comment1",
            PostId = 1,
            UserId = 1,
        };
        Comment comment2 = new()
        {
            Id = 2,
            Body = "comment2",
            PostId = 2,
            UserId = 2,
        };
        Comment comment3 = new()
        {
            Id = 3,
            Body = "comment3",
            PostId = 2,
            UserId = 2,
        };
        await AddAsync(comment1);
        await AddAsync(comment2);
        await AddAsync(comment3);
    }
    }
