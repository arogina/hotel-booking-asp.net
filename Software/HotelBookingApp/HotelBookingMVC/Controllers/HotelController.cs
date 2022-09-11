using Microsoft.AspNetCore.Mvc;
using BLL.Hotel;
using DAL.Models;
using BLL.Exceptions;
using BLL.Room;

namespace HotelBookingMVC.Controllers
{
    public class HotelController : Controller
    {
        private IHotelRepository _hotelRepository;
        private IRoomRepository _roomRepository;

        public HotelController(IHotelRepository hotelRepository, IRoomRepository roomRepository)
        {
            this._hotelRepository = hotelRepository;
            this._roomRepository = roomRepository;
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
            try
            {
                this._hotelRepository.DodajOcjenu(id, (int)HttpContext.Session.GetInt32("id"), ocjena);
            } catch (AlreadyRatedException ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var sobe = await this._roomRepository.DohvatiSobePoHotelu(id);
            var hotel = await this._hotelRepository.DohvatiHotel(id);
            ViewBag.Hotel = hotel.Naziv;
            ViewBag.HotelId = hotel.HotelId;

            return View(sobe);
        }
    }
}
