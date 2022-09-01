using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Reservation
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelBookingContext _bookingContext;

        public ReservationRepository(HotelBookingContext bookingContext)
        {
            this._bookingContext = bookingContext;
        }

        public async Task<Rezervacija> DohvatiRezervaciju(int id)
        {
            return await _bookingContext.Rezervacijas.FindAsync(id);
        }

        public async Task<List<Rezervacija>> DohvatiKorisnikoveRezervacije(int korisnikId)
        {
            return await (from r in _bookingContext.Rezervacijas where r.KorisnikId == korisnikId select r)
                .Include("Korisnik")
                .Include("Soba")
                .Include("OznakaStatusaNavigation")
                .ToListAsync();
        }

        public bool IzbrišiRezervaciju(Rezervacija rezervacija)
        {
            var soba = (from s in _bookingContext.Sobas where s.SobaId == rezervacija.SobaId select s).First();
            soba.Rezervirana = false;
            _bookingContext.Remove(rezervacija);

            return _bookingContext.SaveChanges() > 0;
        }

        public bool KreirajRezervaciju(Rezervacija rezervacija)
        {
            _bookingContext.Add(rezervacija);

            return _bookingContext.SaveChanges() > 0;
        }
    }
}
