using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Entity
{
    [Table("CustomerLogin")]
    public partial class customerLogin
    {
        [Key]
        public int LoginId { get; set; }
        
        [ForeignKey("customer")]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }



    }
}
