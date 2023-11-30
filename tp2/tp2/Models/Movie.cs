using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tp2.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        // Foreign key pour la relation avec le genre
        [ForeignKey("Genre")]
        public Guid GenreId { get; set; }

        // Propriété de navigation pour représenter que chaque film correspond à un seul genre
        public virtual Genre Genre { get; set; }
        public Movie()
        {
        }
    }
}
