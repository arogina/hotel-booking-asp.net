using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public partial class Račun
    {
        [Display(Name = "Broj rezervacije")]
        public int RezervacijaId { get; set; }
        [Display(Name = "Račun izradio")]
        public int ZaposlenikId { get; set; }
        [Display(Name = "Ukupna cijena")]
        public double UkupnaCijena { get; set; }
        [Display(Name = "Plaćeno?")]
        public bool Placeno { get; set; }

        public virtual Rezervacija Rezervacija { get; set; } = null!;
        public virtual Zaposlenik Zaposlenik { get; set; } = null!;
    }
}
