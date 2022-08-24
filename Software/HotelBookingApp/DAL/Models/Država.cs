using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Država
    {
        public Država()
        {
            Hotels = new HashSet<Hotel>();
        }

        public string OznakaDrzave { get; set; } = null!;
        public string Naziv { get; set; } = null!;

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
