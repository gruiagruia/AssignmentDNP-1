using BlazorAssignment.Models;

namespace BlazorAssignment.Services;

public interface IUserService
{
    public Task<User> GetUserAsync(string username);
}