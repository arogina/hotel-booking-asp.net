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
    }
}
