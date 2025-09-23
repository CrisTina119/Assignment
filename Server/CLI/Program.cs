using CLI.UI;
using FileRepositories;
using RepositoryContracts.Interfaces;




Console.WriteLine("Starting CLI app.....");
// Instantiate repositories
IUserRepository userInterface = new UserInFileRepository(); // old: UserInMemoryRepository
IPostRepository postinterface = new PostInFileRepository();// old: PostInMemoryRepository
ICommentRepository commentInterface = new CommentInFileRepository();

// Instantiate CLI app
CliApp app = new CliApp(commentInterface, userInterface, postinterface);

// Start CLI
await app.StartAsync();
