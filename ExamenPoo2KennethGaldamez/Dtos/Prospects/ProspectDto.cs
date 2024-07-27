using ExamenPoo2KennethGaldamez.Database.Entities;
using System.ComponentModel.DataAnnotations;

namespace ExamenPoo2KennethGaldamez.Dtos.Prospects
{
    public class ProspectDto
    {
        public string client_Name { get; set; }

        public string identity_number { get; set; }
    }
}
