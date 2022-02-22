﻿using AutoMapper;
using Business.Repository.IRepository;
using DataAcess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
	public class HotelAmenityRepository : IHotelAmenityRepository
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public HotelAmenityRepository(ApplicationDbContext db, IMapper mapper)
		{
			_mapper = mapper;
			_db = db;
		}

		public async Task<HotelAmenityDTO> CreateHotelAmenity(HotelAmenityDTO hotelAmenityDTO)
		{
			HotelAmenity hotelAmenity = _mapper.Map<HotelAmenityDTO, HotelAmenity>(hotelAmenityDTO);
			var addedHotelAmenity = await _db.HotelAmenities.AddAsync(hotelAmenity);
			await _db.SaveChangesAsync();

			return _mapper.Map<HotelAmenity, HotelAmenityDTO>(addedHotelAmenity.Entity);
		}

		public async Task<int> DeleteHotelAmenity(int amenityId)
		{
			var amenityDetails = await _db.HotelAmenities.FindAsync(amenityId);
			if (amenityDetails != null)
			{
				_db.HotelAmenities.Remove(amenityDetails);
				return await _db.SaveChangesAsync();
			}
			return 0;
		}

		public async Task<IEnumerable<HotelAmenityDTO>> GetAllHotelAmenities()
		{
			try
			{
				IEnumerable<HotelAmenityDTO> hotelAmenityDTOs =
					_mapper.Map<IEnumerable<HotelAmenity>, IEnumerable<HotelAmenityDTO>>
					(_db.HotelAmenities);

				return hotelAmenityDTOs;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<HotelAmenityDTO> GetHotelAmenity(int amenityId)
		{
			try
			{
				HotelAmenityDTO hotelAmenity = _mapper.Map<HotelAmenity, HotelAmenityDTO>(await _db.HotelAmenities.FirstOrDefaultAsync(x => x.Id == amenityId));

				return hotelAmenity;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<HotelAmenityDTO> IsAmenityUnique(string name, int amenityId = 0)
		{
			try
			{
				if (amenityId == 0)
				{
					HotelAmenityDTO hotelAmenity = _mapper.Map<HotelAmenity, HotelAmenityDTO>(await _db.HotelAmenities.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));

					return hotelAmenity;
				}
				else
				{
					HotelAmenityDTO hotelAmenity = _mapper.Map<HotelAmenity, HotelAmenityDTO>(await _db.HotelAmenities.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()
					&& x.Id != amenityId));

					return hotelAmenity;
				}
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<HotelAmenityDTO> UpdateHotelAmenity(int amenityId, HotelAmenityDTO hotelAmenityDTO)
		{
			try
			{
				if (amenityId == hotelAmenityDTO.Id)
				{
					//valid
					HotelAmenity amenityDetails = await _db.HotelAmenities.FindAsync(amenityId);
					HotelAmenity amenity = _mapper.Map<HotelAmenityDTO, HotelAmenity>(hotelAmenityDTO, amenityDetails);
					var updatedAmenity = _db.HotelAmenities.Update(amenity);
					await _db.SaveChangesAsync();
					return _mapper.Map<HotelAmenity, HotelAmenityDTO>(updatedAmenity.Entity);
				}
				else
				{
					//invalid
					return null;
				}
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
