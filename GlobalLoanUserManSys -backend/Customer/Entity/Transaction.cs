using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Entity
{
    [Table("Transaction")]
    public partial class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransacId { get; set; }

        [ForeignKey("customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Account")]
        public int AccntId { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string? TransacType { get; set; }
        public int TransacAmnt { get; set; }
        public DateTime TransacDate { get; set; }
    }
}
