using System.ComponentModel.DataAnnotations;

namespace HotelBookingMVC.Models
{
    #nullable disable warnings
    public class RegistracijaModel
    {
        [Required (ErrorMessage = "Ovo polje je obavezno!")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        [DataType (DataType.Password)]
        public string Lozinka { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        [Display(Name = "Ponovljena lozinka")]
        [DataType(DataType.Password)]
        [Compare("Lozinka")]
        public string PonovljenaLozinka { get; set; }
    }
}
