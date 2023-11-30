using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TP4.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [ForeignKey("MembershipType")]
        public int MembershipTypeId { get; set; }

        public virtual MembershipType? Membership { get; set; } = null!;
        public virtual ICollection<Movie>? Movie { get; set; } = null!;

    }
}
