using System;
using System.Security.Cryptography.X509Certificates;
using Entities;
using InMemoryRepositories_;
using RepositoryContracts.Interfaces;

namespace CLI.UI.ManageComment;

public class ViewSingleComment
{
    private ICommentRepository commentInterface;

    public ViewSingleComment(ICommentRepository commentInterface)
    {
        this.commentInterface = commentInterface;
    }
    public async Task ShowAsync()
    {
        Console.WriteLine("Enter comment Id: ");
        int commentIdInput = Convert.ToInt32(Console.ReadLine());
        Comment? comment = await commentInterface.GetSingleAsync(commentIdInput);
        if (comment != null)
        {
            System.Console.WriteLine($"ID: {comment.Id}, Body: {comment.Body}, PostID: {comment.PostId}, UserID: {comment.UserId}");
        }
        else
        {
            Console.WriteLine("Comment not found");
        }

    }
}
