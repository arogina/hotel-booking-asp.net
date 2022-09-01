using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public partial class Rezervacija
    {
        public Rezervacija()
        {
            Računs = new HashSet<Račun>();
        }

        [Display(Name = "ID")]
        public int RezervacijaId { get; set; }

        [Display(Name = "Rezervirano na datum")]
        public DateTime DatumRezervacije { get; set; }

        [Display(Name = "Rezervirano-od")]
        [DataType(DataType.Date)]
        public DateTime RezervacijaOd { get; set; }

        [Display(Name = "Rezervirano-do")]
        [DataType(DataType.Date)]
        public DateTime RezervacijaDo { get; set; }

        [Display(Name = "Broj noćenja")]
        public int BrojNocenja { get; set; }

        [Display(Name = "Korisnik")]
        public int KorisnikId { get; set; }

        [Display(Name = "Soba")]
        public int SobaId { get; set; }

        [Display(Name = "Status rezervacije")]
        public string? OznakaStatusa { get; set; }

        public virtual Korisnik Korisnik { get; set; } = null!;
        public virtual StatusRezervacije? OznakaStatusaNavigation { get; set; }
        public virtual Soba Soba { get; set; } = null!;
        public virtual ICollection<Račun> Računs { get; set; }
    }
}
