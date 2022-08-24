using HotelBookingMVC.Models;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using BLL.Account;
using BLL.Exceptions;
using BLL;

namespace HotelBookingMVC.Controllers
{
    public class AuthorizationController : Controller
    {
        private IAccountRepository _accountRepository;

        public AuthorizationController(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind("Ime, Prezime, Email, Lozinka")] RegistracijaModel korisnik)
        {
            if (korisnik != null)
            {
                string sol = Security.CreateSalt();
                string hashLozinka = Security.HashPassword(korisnik.Lozinka, sol);

                _accountRepository.RegistrirajKorisnika(new Korisnik()
                {
                    Ime = korisnik.Ime,
                    Prezime = korisnik.Prezime,
                    Email = korisnik.Email,
                    Lozinka = hashLozinka,
                    LozinkaSol = sol
                });
            }

            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string lozinka)
        {
            try
            {
                Korisnik korisnik = _accountRepository.AutentificirajKorisnika(email, lozinka);
                HttpContext.Session.SetInt32("id", korisnik.KorisnikId);
                //HttpContext.Session.SetInt32("tipKorisnika", korisnik.TipKorisnikaId); --> promjeniti u bazi TipKorisnikaId u not null
            } 
            catch (InvalidAccountEmailException ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            } 
            catch (WrongAccountPasswordException ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("id");

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
