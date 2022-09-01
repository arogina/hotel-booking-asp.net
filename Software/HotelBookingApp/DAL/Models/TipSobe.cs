using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class TipSobe
    {
        public TipSobe()
        {
            Sobas = new HashSet<Soba>();
        }

        public int TipSobeId { get; set; }
        public string Naziv { get; set; } = null!;
        public double CijenaPoNocenju { get; set; }

        public virtual ICollection<Soba> Sobas { get; set; }
    }
}
