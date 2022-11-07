using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Entity
{
    [Table("Customer")]
    public partial class customer
    {
        
        
            [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int CustomerId { get; set; }
        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string MiddleName { get; set; }
            public string CustomerCity { get; set; }
            public string CustomerContactNo { get; set; }
            
            public string Occupation { get; set; }
            
            public string CustomerDob     { get; set; }


            


    
    }
}
