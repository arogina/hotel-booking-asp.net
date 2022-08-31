using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HotelBookingContext _bookingContext;
        public EmployeeRepository(HotelBookingContext bookingContext)
        {
            this._bookingContext = bookingContext;
        }

        public async Task<List<Zaposlenik>> DohvatiZaposlenikeHotela(int hotelId)
        {
            return await (from z in _bookingContext.Zaposleniks
                          where z.HotelId == hotelId
                          select z).ToListAsync();
        }
    }
}
