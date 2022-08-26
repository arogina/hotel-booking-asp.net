using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Hotel
{
    
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelBookingContext _bookingContext;

        public HotelRepository(HotelBookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }

        public async Task<DAL.Models.Hotel> DohvatiHotel(int id)
        {
            return await _bookingContext.Hotels.FindAsync(id);
        }

        public async Task<List<DAL.Models.Hotel>> DohvatiSveHotele()
        {
            return await _bookingContext.Hotels.ToListAsync();
        }
    }
}
