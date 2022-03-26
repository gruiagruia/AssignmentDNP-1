using System.Text.Json;
using Application.Entities;

namespace FileData.DataAccess;

public class FileContext
{
    private string postFilePath = "posts.json";
    private ICollection<Post> posts;

    public ICollection<Post> Posts
    {
        get
        {
            if (posts == null)
            {
                LoadData();
            }

            return posts;
        }
    }

    public FileContext()
    {
        if (!File.Exists(postFilePath))
        {
            Seed();
        }
    }
    
    private void Seed()
    {
        Post[] ts = {
            new Post("Darius", "McDonalds bad?","i don't know") {
                Id = 1,
            },
            new Post("Vali", "Walking the dog 101","is not that easy") {
                Id = 2,
            },
            new Post("Dorutzu", "Doing homework","hmu") {
                Id = 3,
            },
            new Post("Nebunu1", "Eat breakfast","bulking stuff") {
                Id = 4,
            },
            new Post("Coman", "Mow lawn","has never been easier") {
                Id = 5,
            },
        };
        posts = ts.ToList();
        SaveChanges();
    }
    
    public void SaveChanges()
    {
        string serialize = JsonSerializer.Serialize(Posts);
        File.WriteAllText(postFilePath,serialize);
        posts = null;
    }
    
    private void LoadData()
    {
        string content = File.ReadAllText(postFilePath);
        posts = JsonSerializer.Deserialize<List<Post>>(content);
    }

}