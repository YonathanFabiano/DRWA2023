using Microsoft.EntityFrameworkCore;

namespace UTS_DRWA.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<Guru> TodoItems { get; set; } = null!;
}