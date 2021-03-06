using BlazorAssignment.Models;

namespace BlazorAssignment.Services.Impls;

public class InMemoryUserService : IUserService
{
    public async Task<User?> GetUserAsync(string username)
    {
        User? find = users.Find(user => user.Name.Equals(username));
        return find;
    }

    public void AddUserAsync(string username, string password )
    {
        User newUser = new User(username, password, "Regular User", 2);
        users.Add(newUser);
    }

    private List<User> users = new()
    {
        new User("Gruia", "Pass1234", "CEO", 5),
        new User("Maria", "oneTwo3FOUR", "Student", 2),
        new User("Anne", "password", "Secretary", 3)        
    };
}