using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenPoo2KennethGaldamez.Database.Entities
{
    [Table("loans", Schema = "dbo")]
    public class LoanEntity : BaseEntity
    {

        [Required]
        [Column("Loan_amount")]
        public float Loan_amount { get; set; }

        [Required]
        [Column("comission_rate")]
        public float tasa_comision { get; set; }

        [Required]
        [Column("interest_rate")]
        public float tasa_interes { get; set; }

        [Required]
        [Column("plazos")]
        public int plazo { get; set; }

        [Column("client_id")]
        public Guid ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual ProspectEntity Client { get; set; }
    }
}
