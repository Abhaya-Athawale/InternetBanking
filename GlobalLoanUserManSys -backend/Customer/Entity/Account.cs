using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Entity
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int AccntId { get; set; }

        [ForeignKey("customer")]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string? Branch { get; set; }

        [DefaultValue(0)]
        public int AccntBalance { get; set; }
    }
}
