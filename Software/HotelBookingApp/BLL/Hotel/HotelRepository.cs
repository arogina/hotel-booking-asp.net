using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using BLL.Exceptions;

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

        public bool StvoriHotel(DAL.Models.Hotel hotel)
        {
            _bookingContext.Hotels.Add(hotel);

            return _bookingContext.SaveChanges() > 0;
        }

        public bool IzmjeniHotel(int id, DAL.Models.Hotel hotel)
        {
            var exHotel = _bookingContext.Hotels.Find(id);
            exHotel.Naziv = hotel.Naziv;
            exHotel.Adresa = hotel.Adresa;
            exHotel.Opis = hotel.Opis;
            exHotel.ProsjecnaOcjena = hotel.ProsjecnaOcjena;
            exHotel.BrojKatova = hotel.BrojKatova;
            exHotel.OznakaDrzave = hotel.OznakaDrzave;

            return _bookingContext.SaveChanges() > 0;
        }

        public bool IzbrišiHotel(int id)
        {
            var hotel =  _bookingContext.Hotels.Find(id);
            _bookingContext.Hotels.Remove(hotel);

            return _bookingContext.SaveChanges() > 0;
        }

        public void DodajOcjenu(int hotelId, int korisnikId, int ocjena)
        {
            Ocjenio ocjenio = new Ocjenio
            {
                HotelId = hotelId,
                KorisnikId = korisnikId,
                Ocjena = ocjena
            };

            if (_bookingContext.Ocjenios.Contains(ocjenio))
            {
                throw new AlreadyRatedException("Ovaj korisnik je već ocjenio navedeni hotel!");
            }

            _bookingContext.Ocjenios.Add(ocjenio);
            _bookingContext.SaveChanges();

            var hotel = _bookingContext.Hotels.Find(hotelId);
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
