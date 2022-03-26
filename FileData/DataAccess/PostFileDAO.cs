using Application.Contracts;
using Application.Entities;

namespace FileData.DataAccess;

public class PostFileDAO : IPostService
{
    private FileContext fileContext;

    public PostFileDAO(FileContext fileContext)
    {
        this.fileContext = fileContext;
    }
    
    public async Task<ICollection<Post>> GetAsync()
    {
        ICollection<Post> posts = fileContext.Posts;
        return posts;
    }
    
    public async Task<Post> GetById(int id)
    {
        return fileContext.Posts.First(t => t.Id == id);
    }
    
    public async Task<Post> AddAsync(Post post)
    {
        int largestId = fileContext.Posts.Max(t => t.Id);
        int nextId = largestId + 1;
        post.Id = nextId;
        fileContext.Posts.Add(post);
        fileContext.SaveChanges();
        return post;
    }

    public async Task DeleteAsync(int id)
    {
        Post toDelete = fileContext.Posts.First(t => t.Id == id);
        fileContext.Posts.Remove(toDelete);
        fileContext.SaveChanges();
    }

    public async Task UpdateAsync(Post post)
    {
        Post toUpdate = fileContext.Posts.First(t => t.Id == post.Id);
        toUpdate.Owner = post.Owner;
        fileContext.SaveChanges();
    }
}