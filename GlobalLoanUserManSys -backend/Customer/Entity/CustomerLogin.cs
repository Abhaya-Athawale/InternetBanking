using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Entity
{
    [Table("CustomerLogin")]
    public partial class customerLogin
    {
        [Key]
        [Required(ErrorMessage ="Login Id is required!")]
        public int LoginId { get; set; }
        
        [ForeignKey("customer")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage ="Password is required!")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }



    }
}
