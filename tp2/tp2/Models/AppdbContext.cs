using Microsoft.EntityFrameworkCore;
namespace tp2.Models

    /*c'est une session avec la base de données*/
{
    public class AppdbContext : DbContext
    {
        /*In Entity Framework, DbSet is a generic type provided by Entity Framework 
         * that represents a collection of entities (rows) from a database
         * table or a database query result*/
        public DbSet<Movie>? movies { get; set; }
        public DbSet<Genre> genres { get; set; }
        public AppdbContext(DbContextOptions options) : base(options) 
        { }
    }

    }

