using Business.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace HiddenVilla_API.Controllers
{
    [Route("api/[controller]")]
    public class AmenityController : Controller
    {
        private readonly IHotelAmenityRepository _hotelAmenityRepository;

        public AmenityController(IHotelAmenityRepository hotelAmenityRepository)
        {
            _hotelAmenityRepository = hotelAmenityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotelAmenities()
        {
            var allAmenities = await _hotelAmenityRepository.GetAllHotelAmenities();
            if(allAmenities == null || !allAmenities.Any())
            {
                return BadRequest(new ErrorModel()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "No Amenities found"
                });
            }
            return Ok(allAmenities);
        }
    }
}
