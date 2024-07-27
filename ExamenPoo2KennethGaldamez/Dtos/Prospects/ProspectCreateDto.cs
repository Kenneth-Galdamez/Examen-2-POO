using ExamenPoo2KennethGaldamez.Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenPoo2KennethGaldamez.Dtos.Prospects
{
    public class ProspectCreateDto
    {

        [StringLength(50)]
        [Required]
        public string client_Name { get; set; }

        [StringLength(50)]
        [Required]
        public string identity_number { get; set; }

    }
}
