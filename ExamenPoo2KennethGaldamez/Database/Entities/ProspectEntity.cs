using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenPoo2KennethGaldamez.Database.Entities
{
    [Table("prospects", Schema = "dbo")]
    public class ProspectEntity : BaseEntity
    {
        [StringLength(50)]
        [Required]
        [Column("client_name")]
        public string client_Name { get; set; }

        [StringLength(50)]
        [Required]
        [Column("identity")]
        public string identity_number { get; set; }
       
        public virtual IEnumerable<LoanEntity> Loans { get; set; }
    }
}
