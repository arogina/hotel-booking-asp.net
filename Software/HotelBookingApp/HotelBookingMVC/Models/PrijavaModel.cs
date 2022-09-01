using System.ComponentModel.DataAnnotations;

namespace HotelBookingMVC.Models
{
    #nullable disable warnings
    public class PrijavaModel
    {
        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }
    }
}
