using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Bill
{
    public interface IBillRepository
    {
        public Task<Račun> DohvatiRačun(int id);
        public Task<List<Račun>> DohvatiRačunePoKorisniku(int korisnikId);
        public Task<List<Račun>> DohvatiRačuneHotela(int hotelId);
        public bool StvoriRačun(Račun račun);
        public Task<bool> IzbrišiRačun(Račun račun);
        public double IzračunajUkupnuCijenu(int rezervacijaId);
    }
}
