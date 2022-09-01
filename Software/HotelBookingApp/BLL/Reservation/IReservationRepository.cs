using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Reservation
{
    public interface IReservationRepository
    {
        public Task<Rezervacija> DohvatiRezervaciju(int id);
        public Task<List<Rezervacija>> DohvatiKorisnikoveRezervacije(int korisnikId);
        public bool KreirajRezervaciju(Rezervacija rezervacija);
        public bool IzbrišiRezervaciju(Rezervacija rezervacija);
    }
}
