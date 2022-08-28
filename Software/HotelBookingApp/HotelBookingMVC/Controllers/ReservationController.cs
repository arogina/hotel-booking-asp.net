using BLL.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingMVC.Controllers
{
    public class ReservationController : Controller
    {
        private IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            this._reservationRepository = reservationRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
