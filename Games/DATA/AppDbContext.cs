using Games.Entity;
using Microsoft.EntityFrameworkCore;

namespace Games.DATA
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<GameEntity> Games { get; set; }
    }
}
