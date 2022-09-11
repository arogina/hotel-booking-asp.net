using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Room
{
    public interface IRoomRepository
    {
        public Task<Soba> DohvatiSobu(int id);
        public Task<List<Soba>> DohvatiSobePoHotelu(int hotelId);
        public Task<List<Soba>> DohvatiSveSobe();
        public Task KreirajSobu(Soba soba);
        public Task IzmjeniSobu(int id, Soba soba);
        public Task ObrišiSobu(int sobaId);
        public Task<List<TipSobe>> DohvatiTipoveSoba();
    }
}
