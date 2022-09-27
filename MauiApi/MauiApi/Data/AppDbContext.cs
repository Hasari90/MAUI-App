using MauiApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<User> Users => Set<User>();
    }
}
