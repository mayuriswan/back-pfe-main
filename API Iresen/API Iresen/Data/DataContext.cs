using Microsoft.EntityFrameworkCore;
using API_Iresen;
using API_Iresen.Models;

namespace API_Iresen.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Aap> Aaps { get; set; }
        public DbSet<ProjectCall> ProjectCalls { get; set; } // Ajout du DbSet pour ProjectCall

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Assure que la configuration de base est appelée

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
