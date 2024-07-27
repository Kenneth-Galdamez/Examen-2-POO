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
        [Column("interest_rate")]
        public float tasa_interes { get; set; }

        [Required]
        [Column("plazo_meses")]
        public int plazo_meses { get; set; }

        [Required]
        [Column("firstpaymentdate")]
        public DateTime firstpaymentdate { get; set; }


        [Required]
        [Column("disbursementdate")]
        public DateTime disbursementdate { get; set; }


        [Column("client_id")]
        public Guid ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual ProspectEntity Client { get; set; }
    }
}
