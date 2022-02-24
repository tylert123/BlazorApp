using System.ComponentModel.DataAnnotations;

namespace DataAcess.Data
{
    public class HotelAmenity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Timing { get; set; }
        public string? IconStyle { get; set; }
    }
}
