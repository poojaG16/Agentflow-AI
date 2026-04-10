using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Data;

public class AuthDbContext : DbContext
{
    // constructor
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options){}

    public DbSet<User> users => Set<User>();
}
