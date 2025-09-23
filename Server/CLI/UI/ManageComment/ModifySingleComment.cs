using System;
using System.Security.Cryptography.X509Certificates;
using Entities;
using RepositoryContracts.Interfaces;

namespace CLI.UI.ManageComment;

public class ModifySingleComment
{
    private ICommentRepository commentInterface;

    public ModifySingleComment(ICommentRepository commentInterface)
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
        Console.WriteLine("Enter new comment body: ");
        var commentNewBody = Console.ReadLine();
        comment!.Body = commentNewBody!;

        await commentInterface.UpdateAsync(comment);

    }
}
