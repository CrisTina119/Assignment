using System;
using System.Security.Cryptography.X509Certificates;
using Entities;
using InMemoryRepositories_;
using RepositoryContracts.Interfaces;

namespace CLI.UI.ManageComment;

public class CreateCommentView
{
    private ICommentRepository commentInterface;

    public CreateCommentView(ICommentRepository commentInterface)
    {
        this.commentInterface = commentInterface;
    }

    internal async Task ShowAsync()
    {
        Console.WriteLine("Enter comment body: ");
        string? body = Console.ReadLine();

        Console.WriteLine("Enter post Id: ");
        int? postId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Please enter user Id: ");
        int? userId = Convert.ToInt32(Console.ReadLine());

        var comment = new Comment
        {
            Body = body,
            PostId = postId,
            UserId = userId
        };
        await commentInterface.AddAsync(comment);
        Console.WriteLine("Commented created sucefully");
            }
}
