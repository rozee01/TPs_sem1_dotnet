using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TP3net.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            string GenreJSon = File.ReadAllText("Genre.Json");
            List<Genre>? genres = System.Text.Json.
            JsonSerializer.Deserialize<List<Genre>>(GenreJSon);
            //Seed to categorie
            foreach (Genre c in genres)
                model.Entity<Genre>()
                .HasData(c);
        }
    }
    }
