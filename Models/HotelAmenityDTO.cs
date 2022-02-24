using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class HotelAmenityDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Name for this Amenity")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Description for this Amenity")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a Timing for this Amenity")]
        public string Timing { get; set; }
        public string? IconStyle { get; set; }
    }
}
