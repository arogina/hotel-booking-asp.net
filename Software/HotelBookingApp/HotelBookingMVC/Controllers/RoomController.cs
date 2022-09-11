using BLL.Hotel;
using BLL.Room;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingMVC.Controllers
{
    public class RoomController : Controller
    {
        private IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            this._roomRepository = roomRepository;
        }

        public async Task<IActionResult> Create(int hotelId, string hotel)
        {
            var tipovi = await this._roomRepository.DohvatiTipoveSoba();
            ViewData["TipSobe"] = tipovi;
            ViewBag.HotelId = hotelId;
            ViewBag.Hotel = hotel;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrojSobe,BrojKata,HotelId,TipSobeId")] Soba soba)
        {
            await this._roomRepository.KreirajSobu(soba);
            return RedirectToAction("Index", "Hotel");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this._roomRepository.ObrišiSobu(id);
            return RedirectToAction("Index", "Hotel");
        } 

        public async Task<IActionResult> Edit(int sobaId, int hotelId, string hotel)
        {
            var soba = await this._roomRepository.DohvatiSobu(sobaId);
            var tipovi = await this._roomRepository.DohvatiTipoveSoba();
            ViewData["TipSobe"] = tipovi;
            ViewBag.HotelId = hotelId;
            ViewBag.Hotel = hotel;

            return View(soba);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int SobaId, [Bind("BrojSobe,BrojKata,HotelId,TipSobeId")] Soba soba)
        {
            await this._roomRepository.IzmjeniSobu(SobaId, soba);
            return RedirectToAction("Index", "Hotel");
        }
    }
}
