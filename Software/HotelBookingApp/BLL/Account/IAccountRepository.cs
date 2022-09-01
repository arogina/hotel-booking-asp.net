using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Account
{
    public interface IAccountRepository
    {
        public void RegistrirajKorisnika (Korisnik korisnik);
        public Korisnik AutentificirajKorisnika (string email, string lozinka);
        public Task<Korisnik> DohvatiKorisnika(int id);
    }
}
