using AuthService.Data;
using AuthService.Models;

namespace AuthService.services;

public class AuthenticationService
{

    private readonly AuthDbContext _dbContext;

    public AuthenticationService(AuthDbContext authDbContext)
    {
        _dbContext = authDbContext;
    }

    public async Task<User> Register(string email, string password)
    {
        var exsiting = _dbContext.users.FirstOrDefault(u => u.Email == email);
        if (exsiting != null)
        {
            throw new Exception("User already exists");
        }

        var newUser = new User
        {
            Email = email,
            Id = Guid.NewGuid(),
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
        };
        _dbContext.users.Add(newUser);
        await _dbContext.SaveChangesAsync();
        return newUser;
    }

    public User? ValidateUser(string email, string password)
    {
        var user = _dbContext.users.FirstOrDefault(u => u.Email == email);
        if(user == null) return null;

        bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        return isValid ? user : null;
    }
}
