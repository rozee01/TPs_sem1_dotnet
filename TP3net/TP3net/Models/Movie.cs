﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP3net.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; } = null!;

    }
}
