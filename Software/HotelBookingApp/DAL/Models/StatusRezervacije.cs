using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class StatusRezervacije
    {
        public StatusRezervacije()
        {
            Rezervacijas = new HashSet<Rezervacija>();
        }

        public string OznakaStatusa { get; set; } = null!;
        public string Naziv { get; set; } = null!;

        public virtual ICollection<Rezervacija> Rezervacijas { get; set; }
    }
}
