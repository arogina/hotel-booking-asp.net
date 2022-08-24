using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Soba
    {
        public Soba()
        {
            Rezervacijas = new HashSet<Rezervacija>();
        }

        public int SobaId { get; set; }
        public int BrojSobe { get; set; }
        public int BrojKata { get; set; }
        public int HotelId { get; set; }
        public int? TipSobeId { get; set; }
        public bool Rezervirana { get; set; }

        public virtual Hotel Hotel { get; set; } = null!;
        public virtual TipSobe? TipSobe { get; set; }
        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
    }
}
