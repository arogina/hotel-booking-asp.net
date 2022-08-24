using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Zaposlenik
    {
        public Zaposlenik()
        {
            Računs = new HashSet<Račun>();
        }

        public int ZaposlenikId { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string Adresa { get; set; } = null!;
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; } = null!;
        public virtual ICollection<Račun> Računs { get; set; }
    }
}
