using Microsoft.EntityFrameworkCore;
using NotesAPI.Entities;

namespace NotesAPI.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<Category>()
                    .HasData(Enum.GetValues(typeof(Enums.Category))
                        .Cast<Enums.Category>()
                        .Select(e => new Category
                        {
                            Id = (short)e,
                            Description = e.ToString()
                        })
            );
        }

        public DbSet<Note> Note { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
