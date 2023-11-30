using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace TP4.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
    }
}
