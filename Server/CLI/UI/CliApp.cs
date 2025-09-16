using System.Reflection.Metadata;
using CLI.UI.Manage_Post;
using CLI.UI.ManageUser;
using CLI.UI.ManageComment;
using System;
using System.Security.Cryptography.X509Certificates;
using Entities;
using InMemoryRepositories_;
using RepositoryContracts.Interfaces;

namespace CLI.UI;

public class CliApp
{
    public ICommentRepository commentInterface { get; set; }
    public IUserRepository userInterface { get; set; }
    public IPostRepository postinterface { get; set; }

    public ManageUserView manageUserView;
    public ManagerPostView managerPostView;

    public ManageCommentView manageCommentView;
    public CliApp(ICommentRepository commentInterface, IUserRepository  userInterface, IPostRepository postinterface)
    {
        this.commentInterface = commentInterface;
        this.userInterface = userInterface;
        this.postinterface = postinterface;
        this.manageUserView = new ManageUserView(userInterface);
        this.managerPostView = new ManagerPostView(postinterface);
        this.manageCommentView = new ManageCommentView(commentInterface);
    }

    internal async Task StartAsync()
    {
        while (true)
        {
            Console.WriteLine("\n=== Main Menu ===");
            Console.WriteLine("1. Manage User");
            Console.WriteLine("2. Manage Post");
            Console.WriteLine("3. Manage Comment");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await manageUserView.ShowMenuAsync();
                    break;
                case "2":
                    await managerPostView.ShowMenuAsync();
                    break;
                case "3":
                    await manageCommentView.ShowMenuAsync();
                    break;
            }
        }
    }
}
