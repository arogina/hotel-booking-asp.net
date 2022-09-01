using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Ocjenios = new HashSet<Ocjenio>();
            Rezervacijas = new HashSet<Rezervacija>();
            Hotels = new HashSet<Hotel>();
        }

        public int KorisnikId { get; set; }
        [Display(Name = "Ime:")]
        public string Ime { get; set; } = null!;
        [Display(Name = "Prezime:")]
        public string Prezime { get; set; } = null!;
        [Display(Name = "E-mail:")]
        public string Email { get; set; } = null!;
        public string Lozinka { get; set; } = null!;
        [Display(Name = "Adresa:")]
        public string? Adresa { get; set; }
        [Display(Name = "Poštanski broj:")]
        public string? PostanskiBroj { get; set; }
        public int TipKorisnikaId { get; set; }
        public string LozinkaSol { get; set; } = null!;

        public virtual TipKorisnika? TipKorisnika { get; set; }
        public virtual ICollection<Ocjenio> Ocjenios { get; set; }
        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
