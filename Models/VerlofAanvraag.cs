using System.ComponentModel.DataAnnotations;

namespace Geprofs3.Models
{
    public class VerlofAanvraag
    {
        public int Id { get; set; }
        public string? Naam { get; set; }
        public string? Rol { get; set; }
        public string? Afdeling { get; set; }

        [DataType(DataType.Date)]
        public DateTime BeginDatum { get; set; }

        [DataType(DataType.Date)]
        public DateTime EindDatum { get; set; }
        public string? Reden { get; set; }
        public string? Status { get; set; }
    }
}
