using Microsoft.EntityFrameworkCore;
using question04_storage.Models;

namespace question04_storage.Data
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options) { }

        public DbSet<FileMetadata> FileMetadatas { get; set; } = null!;
    }
}