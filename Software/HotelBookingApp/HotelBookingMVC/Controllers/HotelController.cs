using Microsoft.AspNetCore.Mvc;
using BLL.Hotel;
using DAL.Models;

namespace HotelBookingMVC.Controllers
{
    public class HotelController : Controller
    {
        private IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            this._hotelRepository = hotelRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Hotel> hotels = await this._hotelRepository.DohvatiSveHotele();

            return View(hotels);
        }
    }
}
