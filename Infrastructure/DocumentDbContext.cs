using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DocumentDbContext : DbContext
{
    public DocumentDbContext(DbContextOptions<DocumentDbContext> options) : base(options) { }

    public DbSet<Document> Documents { get; set; }
}
