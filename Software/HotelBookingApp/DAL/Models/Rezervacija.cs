using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Rezervacija
    {
        public Rezervacija()
        {
            Računs = new HashSet<Račun>();
        }

        public int RezervacijaId { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public DateTime RezervacijaOd { get; set; }
        public DateTime RezervacijaDo { get; set; }
        public int BrojNocenja { get; set; }
        public int KorisnikId { get; set; }
        public int SobaId { get; set; }
        public string? OznakaStatusa { get; set; }

        public virtual Korisnik Korisnik { get; set; } = null!;
        public virtual StatusRezervacije? OznakaStatusaNavigation { get; set; }
        public virtual Soba Soba { get; set; } = null!;
        public virtual ICollection<Račun> Računs { get; set; }
    }
}
