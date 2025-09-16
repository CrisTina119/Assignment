using System;
using System.Security.Cryptography.X509Certificates;
using Entities;
using InMemoryRepositories_;
using RepositoryContracts.Interfaces;

namespace CLI.UI.ManageUser;

public class ManageUserView
{
    private IUserRepository userInterface;
    private CreateUserView createUserView;
    private ListUserView listUserView;

    public ManageUserView(IUserRepository userInterface)
    {
        this.userInterface = userInterface;
        this.createUserView =  new CreateUserView(userInterface);
        this.listUserView = new ListUserView(userInterface);
            }
       
    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.WriteLine("\n=== Manage User ===");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. List User");
            Console.WriteLine("0. Back");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    await createUserView.ShowAsync();
                    break;
                case "2":
                    await listUserView.ShowAsync();
                    break;
                case "0":
                    return;
            }
        }
    }
}
