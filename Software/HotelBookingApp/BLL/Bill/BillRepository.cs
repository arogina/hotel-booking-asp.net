using DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Bill
{
    public class BillRepository : IBillRepository
    {
        private readonly HotelBookingContext _bookingContext;

        public BillRepository(HotelBookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }

        public async Task<Račun> DohvatiRačun(int id)
        {
            return await _bookingContext.Računs.FindAsync(id);
        }

        public async Task<List<Račun>> DohvatiRačuneHotela(int hotelId)
        {
            return await (from r in _bookingContext.Računs
                    join re in _bookingContext.Rezervacijas on r.RezervacijaId equals re.RezervacijaId
                    join s in _bookingContext.Sobas on re.SobaId equals s.SobaId
                    join h in _bookingContext.Hotels on s.HotelId equals h.HotelId
                    select r)
                    .Include("Rezervacija")
                    .Include("Zaposlenik")
                    .ToListAsync();
        }

        public async Task<List<Račun>> DohvatiRačunePoKorisniku(int korisnikId)
        {
            return await (from r in _bookingContext.Računs
                          join re in _bookingContext.Rezervacijas on r.RezervacijaId equals re.RezervacijaId
                          where re.KorisnikId == korisnikId
                          select r).ToListAsync();
        }

        public async Task<bool> IzbrišiRačun(Račun račun)
        {
            _bookingContext.Računs.Remove(račun);
            return await _bookingContext.SaveChangesAsync() > 0;
        }

        public double IzračunajUkupnuCijenu(int rezervacijaId)
        {
            var paramRezervacijaId = new SqlParameter()
            {
                ParameterName = "rezervacija_id",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = rezervacijaId,
            };

            var paramUkupnaCijena = new SqlParameter()
            {
                ParameterName = "ukupna_cijena",
                SqlDbType = System.Data.SqlDbType.Float,
                Direction = System.Data.ParameterDirection.Output,
            };

            _bookingContext.Database
            .ExecuteSqlRaw($"EXECUTE dbo.spIzračunCijene @rezervacija_id, @ukupna_cijena OUTPUT", paramRezervacijaId, paramUkupnaCijena);

            return (double)paramUkupnaCijena.Value;
        }

        public bool StvoriRačun(Račun račun)
        {
            _bookingContext.Računs.Add(račun);
            return _bookingContext.SaveChanges() > 0;
        }
    }
}
