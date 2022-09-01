using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TipKorisnika
    {
        public TipKorisnika()
        {
            Korisniks = new HashSet<Korisnik>();
        }

        public int TipKorisnikaId { get; set; }
        public string Naziv { get; set; } = null!;

        public virtual ICollection<Korisnik> Korisniks { get; set; }
    }
}
