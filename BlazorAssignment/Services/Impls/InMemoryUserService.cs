using BlazorAssignment.Models;

namespace BlazorAssignment.Services.Impls;

public class InMemoryUserService : IUserService
{
    public async Task<User?> GetUserAsync(string username)
    {
        User? find = users.Find(user => user.Name.Equals(username));
        return find;
    }
    
    private List<User> users = new()
    {
        new User("Gruia", "Pass1234", "CEO", 5,1999,"via"),
        new User("Maria", "oneTwo3FOUR", "Student", 2, 2001,"via"),
        new User("Anne", "password", "Secretary", 3, 1975,"via")        
    };
}