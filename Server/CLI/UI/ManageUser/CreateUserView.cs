using System;
using System.Security.Cryptography.X509Certificates;
using Entities;
using RepositoryContracts.Interfaces;

namespace CLI.UI.ManageUser;

public class CreateUserView
{
    private IUserRepository userInterface;
    public CreateUserView(IUserRepository userInterface)
    {
        this.userInterface = userInterface;
    }
    public async Task ShowAsync()
    {
        Console.Write("Enter username: ");
        string? username = Console.ReadLine();

        Console.Write("Enter password -numbers only-: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int password))
        {
            Console.WriteLine("Invalid password. Please enter digits only.");
            return;
        }
        var user = new User
        {
            Username = username!,
            Password = password
        };
        var addedUser = await userInterface.AddAsync(user);
        Console.WriteLine("User created successfully");
}
}
