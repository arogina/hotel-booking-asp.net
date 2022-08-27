using System.ComponentModel.DataAnnotations;

namespace HotelBookingMVC.Models
{
    public class OcjenaModel
    {
        [Required(ErrorMessage = "Potrebno je unijeti ocjenu!")]
        [Range(0, 5, ErrorMessage = "Ocjena mora biti u rasponu između 1 - 5!")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Potrebno je unijeti broj!")]
        public int Ocjena { get; set; }
    }
}
