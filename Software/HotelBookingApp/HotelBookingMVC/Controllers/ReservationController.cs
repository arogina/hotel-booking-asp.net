using BLL.Reservation;
using BLL.Room;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingMVC.Controllers
{
    public class ReservationController : Controller
    {
        private IReservationRepository _reservationRepository;
        private IRoomRepository _roomRepository;

        public ReservationController(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            this._reservationRepository = reservationRepository;
            this._roomRepository = roomRepository;
        }

        public async Task<IActionResult> UserReservations()
        {
            var rezervacije = await _reservationRepository.DohvatiKorisnikoveRezervacije((int)HttpContext.Session.GetInt32("id"));

            return View(rezervacije);
        }

        public async Task<IActionResult> Create(int id)
        {
            var soba = await _roomRepository.DohvatiSobu(id);
            ViewBag.SobaId = soba.SobaId;
            ViewBag.TipSobe = soba.TipSobe.Naziv;
            ViewBag.Hotel = soba.Hotel.Naziv;
            ViewBag.Cijena = $"{soba.TipSobe.CijenaPoNocenju} HRK";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int sobaid, DateTime RezervacijaOd, DateTime RezervacijaDo)
        {
            var rezervacija = new Rezervacija()
            {
                DatumRezervacije = DateTime.Now,
                RezervacijaOd = RezervacijaOd,
                RezervacijaDo = RezervacijaDo,
                BrojNocenja = (int)(RezervacijaDo - RezervacijaOd).TotalDays, 
                SobaId = sobaid,
                OznakaStatusa = "O",
                KorisnikId = (int)HttpContext.Session.GetInt32("id")
            };

            try
            {
                _reservationRepository.KreirajRezervaciju(rezervacija);
            } catch (DbUpdateException ex)
            {
                ViewBag.Error = ex.InnerException.Message;
                return View();
            }

            return RedirectToAction("UserReservations");
        }

        public async Task<IActionResult> Delete(int id)
        {
            _reservationRepository.IzbrišiRezervaciju(await _reservationRepository.DohvatiRezervaciju(id));
            return RedirectToAction("UserReservations");
        }
    }
}
