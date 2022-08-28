using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Room
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelBookingContext _bookingContext;

        public RoomRepository(HotelBookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }

        public async Task<Soba> DohvatiSobu(int id)
        {
            return await _bookingContext.Sobas.FindAsync(id);
        }

        public async Task<List<Soba>> DohvatiSobePoHotelu(int hotelId)
        {
            return await (from s in _bookingContext.Sobas where s.HotelId == hotelId select s)
                .Include("TipSobe")
                .ToListAsync();
        }

        public async Task<List<Soba>> DohvatiSveSobe()
        {
            return await _bookingContext.Sobas.ToListAsync();
        }
    }
}
