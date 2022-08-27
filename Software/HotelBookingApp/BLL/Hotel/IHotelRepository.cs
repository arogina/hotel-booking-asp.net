using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Hotel
{
    public interface IHotelRepository
    {
        public Task<DAL.Models.Hotel> DohvatiHotel(int id);
        public Task<List<DAL.Models.Hotel>> DohvatiSveHotele();
        public void StvoriHotel(DAL.Models.Hotel hotel);
        public void IzmjeniHotel(int id, DAL.Models.Hotel hotel);
        public void IzbrišiHotel(int id);
        public void DodajOcjenu(int hotelId, int korisnikId, int ocjena);
    }
}
