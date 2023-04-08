using Microsoft.EntityFrameworkCore;
using NotesAPI.Entities;

namespace NotesAPI.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Note> Note { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
