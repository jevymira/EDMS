using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DocumentDbContext : DbContext
{
    public DbSet<Document> Documents { get; set; }
}
