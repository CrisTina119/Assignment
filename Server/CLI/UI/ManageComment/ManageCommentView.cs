using System;
using System.Security.Cryptography.X509Certificates;
using Entities;
using InMemoryRepositories_;
using RepositoryContracts.Interfaces;

namespace CLI.UI.ManageComment;

public class ManageCommentView
{
    private ICommentRepository commentInterface;

    private ViewSingleComment viewSingleComment;

    private CreateCommentView createCommentView;

    public ManageCommentView(ICommentRepository commentInterface)
    {
        this.commentInterface = commentInterface;
        this.createCommentView = new CreateCommentView(commentInterface);
        this.viewSingleComment = new ViewSingleComment(commentInterface);
    }
    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.WriteLine("\n=== Manage Comment ===");
            Console.WriteLine("1. Create Comment");
            Console.WriteLine("2. View Single Comment Using Id");
            Console.WriteLine("0. Back");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    await createCommentView.ShowAsync();
                    break;
                case "2":
                    await viewSingleComment.ShowAsync();
                    break;
                case "0":
                    return;
            }
        }
    }
}