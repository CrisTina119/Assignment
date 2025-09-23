using System;
using System.Security.Cryptography.X509Certificates;
using Entities;
using RepositoryContracts.Interfaces;

namespace CLI.UI.ManageComment;

public class ManageCommentView
{
    private ICommentRepository commentInterface;

    private ViewSingleComment viewSingleComment;

    private ModifySingleComment modifySingleComment;

    private CreateCommentView createCommentView;

    private DeleteSingleCommentView deleteCommentView;

    public ManageCommentView(ICommentRepository commentInterface)
    {
        this.commentInterface = commentInterface;
        this.createCommentView = new CreateCommentView(commentInterface);
        this.viewSingleComment = new ViewSingleComment(commentInterface);
        this.modifySingleComment = new ModifySingleComment(commentInterface);
        this.deleteCommentView = new DeleteSingleCommentView(commentInterface);
    }
    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.WriteLine("\n=== Manage Comment ===");
            Console.WriteLine("1. Create Comment");
            Console.WriteLine("2. View Single Comment Using Id");
            Console.WriteLine("3. Update Single Comment Body");
            Console.WriteLine("4. Delete Single Comment By Id");
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
                case "3":
                    await modifySingleComment.ShowAsync();
                    break;
                case "4":
                    await deleteCommentView.ShowAsync();
                    break;
                case "0":
                    return;
            }
        }
    }
}