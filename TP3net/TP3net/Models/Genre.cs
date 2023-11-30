using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP3net.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GenreName { get; set; }

        public virtual ICollection<Movie> Movie { get; set; } = null!;

    }
}
