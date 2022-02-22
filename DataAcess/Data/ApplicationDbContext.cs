﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        { }

        public DbSet<HotelRoom> HotelRooms { get; set; } //name here used by EF when creating the table in SqlServer
        public DbSet<HotelRoomImage> HotelRoomsImages { get; set; }
		public DbSet<HotelAmenity> HotelAmenities { get; set; }
	}
}
