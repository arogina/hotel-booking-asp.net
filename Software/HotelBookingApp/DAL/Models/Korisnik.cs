using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Ocjenios = new HashSet<Ocjenio>();
            Rezervacijas = new HashSet<Rezervacija>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Lozinka { get; set; } = null!;
        public string? Adresa { get; set; }
        public string? PostanskiBroj { get; set; }
        public int? TipKorisnikaId { get; set; }
        public string LozinkaSol { get; set; } = null!;

        public virtual TipKorisnika? TipKorisnika { get; set; }
        public virtual ICollection<Ocjenio> Ocjenios { get; set; }
        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
    }
}
