using RepositoryContracts.Interfaces;
using System.Text.Json;
using System.Xml.Linq;

namespace FileRepositories;

public class CommentInFileRepository : ICommentRepository
{
//define the file path. We create a file per entity
    private readonly string filePath = "comments.json";

//The constructor ensures there actually is a file
    public CommentInFileRepository()
    {
//If none exists, e.g. the first time the program is run, a new file is created, with the content of an empty list, i.e. no entities. The ”[ ]” is an empty collection in json.
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }
    }
    //the method header, again asynchronous, returning a Task containing the ”finalized” comment, i.e. it now has an ID
    public async Task<Comment> AddAsync(Comment comment)
    {
        //read all the content from the file, this is of course in json format
        string commentsAsJson = await File.ReadAllTextAsync(filePath);
        //The json i deserialized into a list of comments
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson)!;
        int maxId = (int)(comments.Count > 0 ? comments.Max(c => c.Id) : 0); //calculate the next Id to use.
        comment.Id = maxId + 1; //Set the Id.
        comments.Add(comment); //Add the comment to the list
        commentsAsJson = JsonSerializer.Serialize(comments); //Serialize the list to json
        await File.WriteAllTextAsync(filePath, commentsAsJson); //Write the json back to the file
        return comment; //Return the finalized comment, now it has an Id
    }

    public async Task DeleteAsync(int id)
    {
        string commentsAsJson = await File.ReadAllTextAsync(filePath);
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson)!;
        Comment? commentToRemove = comments.SingleOrDefault(c => c.Id == id);
        if (commentToRemove == null)
        {
            throw new InvalidOperationException($"Comment with {id} not found");

        }
        comments.Remove(commentToRemove);
        commentsAsJson = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(filePath, commentsAsJson);
    }

    public IQueryable<Comment> GetManyAsync()
    {
        //ReadAllTextAsync() returns a Task containing a string
        string commentsAsJson = File.ReadAllTextAsync(filePath).Result; //Calling Result, instead of awaiting, will extract the string
        List<Comment> commentsList = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson)!;
        if (commentsList == null)
        {
            Console.WriteLine("Could not retrieve collection.");
            return new List<Comment>().AsQueryable();
        }

        return commentsList.AsQueryable();
    }

    public async Task<Comment?> GetSingleAsync(int id)
    {
        string commentsAsJson = File.ReadAllText(filePath);
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson)!;
        return comments.SingleOrDefault(c => c.Id == id);
    }

    public async Task UpdateAsync(Comment comment)
    {
        string commentsAsJson = File.ReadAllText(filePath);
        List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(commentsAsJson)!;
        int index = comments.FindIndex(c => c.Id == comment.Id);
        if (index == -1)
        {
            throw new InvalidOperationException($"Comment with Id {comment.Id} not found");
        }
        comments[index] = comment;
        commentsAsJson = JsonSerializer.Serialize(comments);
        await File.WriteAllTextAsync(filePath, commentsAsJson);
    }
}