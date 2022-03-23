namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public string Owner { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public Post(string owner, string title, string body)
    {
        Owner = owner;
        Title = title;
        Body = body;
    }
}