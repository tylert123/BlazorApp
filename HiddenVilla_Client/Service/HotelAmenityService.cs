using HiddenVilla_Client.Service.IService;
using Models;
using Newtonsoft.Json;

namespace HiddenVilla_Client.Service
{
    public class HotelAmenityService : IHotelAmenityService
    {
        private readonly HttpClient _client;
        public HotelAmenityService(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<HotelAmenityDTO>> GetHotelAmenities()
        {
            var response = await _client.GetAsync("api/amenity");
            var content = await response.Content.ReadAsStringAsync();
            var amenities = JsonConvert.DeserializeObject<IEnumerable<HotelAmenityDTO>>(content);

            return amenities;
        }

        public Task<HotelAmenityDTO> GetHotelAmenityDetails(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
