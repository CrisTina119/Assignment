namespace Entities;

public class Post
{
    public string? Username { get; set;}
    public int Passsword { get; set; }
     public required string Body { get; set; }
     public required string Title { get; set; }
     public int Id { get; set; }
      public int UserId { get; set; }

public Post()
    {
    }

}
