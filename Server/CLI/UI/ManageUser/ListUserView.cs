using System;
using System.Security.Cryptography.X509Certificates;
using Entities;
using RepositoryContracts.Interfaces;

namespace CLI.UI.ManageUser;

public class ListUserView
{
    private IUserRepository userInterface;

    public ListUserView(IUserRepository userInterface)
    {
        this.userInterface = userInterface;
    }
     public async Task ShowAsync()
    {
        var users = userInterface.GetManyAsync();
        Console.WriteLine("\n=== All Users ===");
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Username: {user.Username}");
        }
    }
}
