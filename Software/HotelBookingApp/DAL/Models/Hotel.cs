using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Ocjenios = new HashSet<Ocjenio>();
            Sobas = new HashSet<Soba>();
            Zaposleniks = new HashSet<Zaposlenik>();
        }

        public int HotelId { get; set; }
        public string Naziv { get; set; } = null!;
        public string Adresa { get; set; } = null!;
        public string? Opis { get; set; }
        public double? ProsjecnaOcjena { get; set; }
        public int BrojKatova { get; set; }
        public string? OznakaDrzave { get; set; }

        public virtual Država? OznakaDrzaveNavigation { get; set; }
        public virtual ICollection<Ocjenio> Ocjenios { get; set; }
        public virtual ICollection<Soba> Sobas { get; set; }
        public virtual ICollection<Zaposlenik> Zaposleniks { get; set; }
    }
}
