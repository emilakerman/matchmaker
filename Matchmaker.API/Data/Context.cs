using Microsoft.EntityFrameworkCore;
using Matchmaker.API.Models;

namespace Matchmaker.API.Data;

public class Context : DbContext
{
    public DbSet<User> Users => Set<User>();
    // public DbSet<Message> Messages => Set<Message>();

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }
}
