using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using BLL.Exceptions;

namespace BLL.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly HotelBookingContext _bookingContext;

        public AccountRepository(HotelBookingContext bookingContext)
        {
            this._bookingContext = bookingContext;
        }

        public void RegistrirajKorisnika (Korisnik korisnik)
        {
            _bookingContext.Add(korisnik);
            _bookingContext.SaveChanges();
        }

        public Korisnik AutentificirajKorisnika (string email, string lozinka)
        {
            var korisnik = _bookingContext.Korisniks.Where(k => k.Email == email).FirstOrDefault();

            if (korisnik == null) throw new InvalidAccountEmailException("Nije pronađen korisnik s navedenim e-mailom!");

            string postojecaLozinka = korisnik.Lozinka;
            string sol = korisnik.LozinkaSol;

            if (!Security.IsEqualPassword(lozinka, sol, postojecaLozinka)) throw new WrongAccountPasswordException("Pogrešna lozinka!");

            return korisnik;
        }
    }
}
