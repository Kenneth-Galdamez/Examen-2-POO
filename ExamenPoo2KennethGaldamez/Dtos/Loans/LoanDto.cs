
using ExamenPoo2KennethGaldamez.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenPoo2KennethGaldamez.Dtos.Loans
{
    public class LoanDto
    {

        public float Loan_amount { get; set; }

        public float principal { get; set; }

        public float saldo { get; set; }

        public float tasa_interes { get; set; }


        public int plazo { get; set; }

        public float levelpayment { get; set; }

        public Guid ClientId { get; set; }

    }
}
