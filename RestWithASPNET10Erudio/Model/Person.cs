using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET10Erudio.Model
{
    [Table("person")]
    public class Person
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(80)]
        [Column("first_name", TypeName ="varchar(80")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(80)]
        [Column("last_name", TypeName = "varchar(80")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("address", TypeName = "varchar(100")]
        public string Address { get; set; }

        [Required]
        [MaxLength(6)]
        [Column("gender", TypeName = "varchar(6")] // Male, Female, Other
        public string Gender { get; set; }   
    }
}
