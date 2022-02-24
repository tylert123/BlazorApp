using AutoMapper;
using DataAcess.Data;
using Models;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HotelRoomDTO, HotelRoom>();
            CreateMap<HotelRoom, HotelRoomDTO>();

            CreateMap<HotelRoomImage, HotelRoomImageDTO>().ReverseMap(); //same as the 2 lines above

            CreateMap<HotelAmenity, HotelAmenityDTO>().ReverseMap();
        }
    }
}
