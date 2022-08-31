using BLL.Bill;
using BLL.Employee;
using BLL.Hotel;
using BLL.Reservation;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace HotelBookingMVC.Controllers
{
    public class BillController : Controller
    {
        private IBillRepository _billRepository;
        private IReservationRepository _reservationRepository;
        private IHotelRepository _hotelRepository;
        private IEmployeeRepository _employeeRepository;

        public BillController(
            IBillRepository billRepository, 
            IReservationRepository reservationRepository,
            IHotelRepository hotelRepository,
            IEmployeeRepository employeeRepository
        )
        {
            this._billRepository = billRepository;
            this._reservationRepository = reservationRepository;
            this._hotelRepository = hotelRepository;
            this._employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> UserBills()
        {
            int id = (int)HttpContext.Session.GetInt32("id");
            var računi = await _billRepository.DohvatiRačunePoKorisniku(id);

            return View(računi);
        }

        public async Task<IActionResult> Create(int id)
        {
            var rezervacija = await _reservationRepository.DohvatiRezervaciju(id);
            var hotel = await _hotelRepository.DohvatiHotelPremaRezervaciji(rezervacija);
            var zaposlenici = await _employeeRepository.DohvatiZaposlenikeHotela(hotel.HotelId);
            ViewData["Hotel"] = hotel;
            ViewData["Rezervacija"] = rezervacija;
            ViewData["Zaposlenici"] = zaposlenici;
            ViewBag.UkupnaCijena = _billRepository.IzračunajUkupnuCijenu(rezervacija.RezervacijaId);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezervacijaId, ZaposlenikId, UkupnaCijena")] Račun račun)
        {
            try
            {
                _billRepository.StvoriRačun(račun);
            } catch(DbUpdateException ex)
            {
                ViewBag.Error = ex.InnerException.Message;
                var rezervacija = await _reservationRepository.DohvatiRezervaciju(račun.RezervacijaId);
                var hotel = await _hotelRepository.DohvatiHotelPremaRezervaciji(rezervacija);
                var zaposlenici = await _employeeRepository.DohvatiZaposlenikeHotela(hotel.HotelId);
                ViewData["Hotel"] = hotel;
                ViewData["Rezervacija"] = rezervacija;
                ViewData["Zaposlenici"] = zaposlenici;
                ViewBag.UkupnaCijena = _billRepository.IzračunajUkupnuCijenu(rezervacija.RezervacijaId);

                return View();
            }

            return RedirectToAction("UserBills");
        }
    }
}
