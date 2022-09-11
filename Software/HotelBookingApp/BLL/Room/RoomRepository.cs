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
            return await (from s in _bookingContext.Sobas where s.SobaId == id select s)
                .Include("Hotel")
                .Include("TipSobe")
                .FirstAsync();
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

        public async Task KreirajSobu(Soba soba)
        {
            this._bookingContext.Sobas.Add(soba);
            await this._bookingContext.SaveChangesAsync();
        }

        public async Task IzmjeniSobu(int id, Soba soba)
        {
            var exSoba = _bookingContext.Sobas.Find(id);
            exSoba.BrojSobe = soba.BrojSobe;
            exSoba.TipSobeId = soba.TipSobeId;
            exSoba.BrojKata = soba.BrojKata;
            await this._bookingContext.SaveChangesAsync();
        }

        public async Task ObrišiSobu(int sobaId)
        {
            var soba = await this._bookingContext.Sobas.FindAsync(sobaId);
            this._bookingContext.Sobas.Remove(soba);
            await this._bookingContext.SaveChangesAsync();
        }

        public async Task<List<TipSobe>> DohvatiTipoveSoba()
        {
            return await this._bookingContext.TipSobes.ToListAsync(); 
        }
    }
}
