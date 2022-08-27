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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Naziv,Adresa,Opis,BrojKatova,OznakaDrzave")] Hotel hotel)
        {
            _hotelRepository.StvoriHotel(hotel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var hotel = await this._hotelRepository.DohvatiHotel(id);

            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Naziv,Adresa,Opis,ProsjecnaOcjena,BrojKatova,OznakaDrzave")] Hotel hotel)
        {
            _hotelRepository.IzmjeniHotel(id, hotel);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
             _hotelRepository.IzbrišiHotel(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Rate(int id)
        {
            var hotel = await this._hotelRepository.DohvatiHotel(id);

            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Rate(int id, int ocjena)
        {
            this._hotelRepository.DodajOcjenu(id, (int)HttpContext.Session.GetInt32("id"), ocjena);

            return RedirectToAction("Index");
        }
    }
}
