using br.com.toodoo.core.FormAggregate;
using Microsoft.EntityFrameworkCore;

namespace br.com.toodoo.infrastructure.Database.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<Form> Forms { get; set; }
}