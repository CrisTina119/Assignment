using System;
using System.Security.Cryptography.X509Certificates;
using Entities;
using RepositoryContracts.Interfaces;

namespace CLI.UI.Manage_Post;

public class ViewSinglePostView
{
    private IPostRepository postInterface;
   // private ICommentRepository commentInterface;
    
     public ViewSinglePostView(IPostRepository postInterface/*,ICommentRepository commentInterface*/)
    {
        this.postInterface = postInterface;
        //this.commentInterface = commentInterface;
    }
    public async Task ShowAsync()
    {
       
        Console.WriteLine("Enter post Id: ");
        int postIdInput = Convert.ToInt32(Console.ReadLine());
        int commentIdInput = Convert.ToInt32(Console.ReadLine());
      //Post? post = await PostInMemoryRepository.GetSingleAsync(postIdInput);
        Post? postId = await postInterface.GetSingleAsync(commentIdInput);
        if (postId != null)
        {
            System.Console.WriteLine($"ID: {postId.Id},Title :{postId.Title} Body: {postId.Body}, UserID: {postId.UserId}");
        }
        else
        {
            Console.WriteLine("Comment not found");
        }

    }
}
