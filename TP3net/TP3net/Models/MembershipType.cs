using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TP3net.Models
{
    [Table("MembershipTypes")]
    public class MembershipType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal SignupFee { get; set; }

        [Required]
        public int DurationInMonths { get; set; }

        [Required]
        public float DiscountRate { get; set; }

        // Navigation property to many Customers
        public virtual ICollection<Customer>? Customers { get; set; }

    }
}
