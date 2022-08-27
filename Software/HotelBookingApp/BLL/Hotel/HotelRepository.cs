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

        public void StvoriHotel(DAL.Models.Hotel hotel)
        {
            _bookingContext.Hotels.Add(hotel);
            _bookingContext.SaveChanges();
        }

        public void IzmjeniHotel(int id, DAL.Models.Hotel hotel)
        {
            var exHotel = _bookingContext.Hotels.Find(id);
            exHotel.Naziv = hotel.Naziv;
            exHotel.Adresa = hotel.Adresa;
            exHotel.Opis = hotel.Opis;
            exHotel.ProsjecnaOcjena = hotel.ProsjecnaOcjena;
            exHotel.BrojKatova = hotel.BrojKatova;
            exHotel.OznakaDrzave = hotel.OznakaDrzave;
            _bookingContext.SaveChanges();
        }

        public void IzbrišiHotel(int id)
        {
            var hotel =  _bookingContext.Hotels.Find(id);
            _bookingContext.Hotels.Remove(hotel);
            _bookingContext.SaveChanges();
        }

        public void DodajOcjenu(int hotelId, int korisnikId, int ocjena)
        {
            var hotel = _bookingContext.Hotels.Find(hotelId);
            _bookingContext.Ocjenios.Add(new Ocjenio
            {
                HotelId = hotelId,
                KorisnikId = korisnikId,
                Ocjena = ocjena
            });

            _bookingContext.SaveChanges();

            int suma = 0;
            int kolicina = 0;
            foreach (var item in _bookingContext.Ocjenios)
            {
                if (item.HotelId == hotelId)
                {
                    suma += item.Ocjena;
                    kolicina++;
                }
            }

            float prosjecnaOcjena = suma / kolicina;
            hotel.ProsjecnaOcjena = prosjecnaOcjena;

            _bookingContext.SaveChanges();
        }
    }
}
