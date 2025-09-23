using RepositoryContracts.Interfaces;

namespace CLI.UI.ManageComment;

public class DeleteSingleCommentView
{
    private ICommentRepository commentInterface;

    public DeleteSingleCommentView(ICommentRepository commentInterface)
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
        Console.WriteLine("Confirm delete comment y/n ");
        var confirm = Console.ReadLine();
        if (confirm == "y")
        {
            await commentInterface.DeleteAsync(commentIdInput);
        }


    }
}
