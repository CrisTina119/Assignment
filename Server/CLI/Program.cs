using RepositoryContracts;
using CLI.UI;
using InMemoryRepositories_;
using RepositoryContracts.Interfaces;




Console.WriteLine("Starting CLI app.....");
        // Instantiate repositories
        IUserRepository userInterface =  new UserInMemoryRepository();
        IPostRepository postinterface = new PostInMemoryRepository();
        ICommentRepository commentInterface =  new CommentInMemoryRepository();

        // Instantiate CLI app
        CliApp app = new CliApp(commentInterface, userInterface, postinterface);

        // Start CLI
        await app.StartAsync();
