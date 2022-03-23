using Domain.Models;

namespace Domain.Contracts;

public interface IPostService
{
    public Task<ICollection<Post>> GetAsync();
    public Task<Post> GetById(int id);
    public Task<Post> AddAsync(Post todo);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(Post todo);
}