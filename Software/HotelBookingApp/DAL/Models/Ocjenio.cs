using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Ocjenio
    {
        public int KorisnikId { get; set; }
        public int HotelId { get; set; }
        public int Ocjena { get; set; }

        public virtual Hotel Hotel { get; set; } = null!;
        public virtual Korisnik Korisnik { get; set; } = null!;
    }
}
