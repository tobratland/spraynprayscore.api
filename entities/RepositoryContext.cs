using Microsoft.EntityFrameworkCore;
using spraynprayscore.api.entities.Models;


namespace spraynprayscore.api.entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }
        
        public DbSet<Score> Scores { get; set; }
    }
}
