using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class CodeFirstDbContext : DbContext
    {
        public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options ) : base( options ) { }
    
        public DbSet<Item> Items { get; set; }
    
    }
}
