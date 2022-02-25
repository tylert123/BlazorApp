using Models;

namespace HiddenVilla_Client.Service.IService
{
    public interface IHotelAmenityService
    {
        public Task<IEnumerable<HotelAmenityDTO>> GetHotelAmenities();
        public Task<HotelAmenityDTO> GetHotelAmenityDetails(int roomId);
    }
}
