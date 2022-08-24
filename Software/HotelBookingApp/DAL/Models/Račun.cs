using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Račun
    {
        public int RezervacijaId { get; set; }
        public int ZaposlenikId { get; set; }
        public double UkupnaCijena { get; set; }
        public bool Placeno { get; set; }

        public virtual Rezervacija Rezervacija { get; set; } = null!;
        public virtual Zaposlenik Zaposlenik { get; set; } = null!;
    }
}
