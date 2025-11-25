namespace Entities;
public class User
{
    public string? Username { get; set;}
    public int Passsword { get; set; }
    public int Id   { get; set; }

    public ICollection<Post> posts = new List<Post>();

    public ICollection<Comment> comments = new List<Comment>();
    public User()
    {
        
    }
 
 }