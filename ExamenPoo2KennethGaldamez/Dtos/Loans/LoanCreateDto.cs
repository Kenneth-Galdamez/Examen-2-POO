using ExamenPoo2KennethGaldamez.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ExamenPoo2KennethGaldamez.Dtos.Loans
{
    public class LoanCreateDto
    {
        [StringLength(50)]
        [Required]
        public string client_Name { get; set; }

        [StringLength(50)]
        [Required]
        public string identity_number { get; set; }

        [Required]
        public float Loan_amount { get; set; }



        [Required]

        public DateTime firstpaymentdate { get; set; }


        [Required]

        public DateTime disbursementdate { get; set; }


        [Required]

        public float tasa_interes { get; set; }

        [Required]
        public int plazo { get; set; }



    }
}
