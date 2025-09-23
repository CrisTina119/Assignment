using System;
using System.Security.Cryptography.X509Certificates;
using Entities;
using RepositoryContracts.Interfaces;

namespace CLI.UI.Manage_Post;


public class ManagerPostView
{
    private IPostRepository postInterface;
    private CreatePostView createPostView;
    private PostListView postListView;
    private ViewSinglePostView viewSinglePostView;

    public ManagerPostView(IPostRepository postInterface)
    {
        this.postInterface = postInterface;
        this.createPostView = new CreatePostView(postInterface);
        this.postListView = new PostListView(postInterface);
        this.viewSinglePostView = new ViewSinglePostView(postInterface);
    }
       
    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.WriteLine("\n=== Manage Post ===");
            Console.WriteLine("1. Create Post");
            Console.WriteLine("2. List Posts");
            Console.WriteLine("3. View single Post by Id: ");
            Console.WriteLine("0. Back");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    await createPostView.ShowAsync();
                    break;
                case "2":
                    await postListView.ShowAsync();
                    break;
                case "3":
                    await viewSinglePostView.ShowAsync();
                    break;
                case "0":
                    return;
            }
        }
    }
}
