using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithASPNET10Erudio.Model.Base;

namespace RestWithASPNET10Erudio.Model
{
    [Table("person")]
    public class Person : BaseEntity
    {
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

        [NotMapped]
        public DateTime? BirthDay { get; set; }
    }
}
