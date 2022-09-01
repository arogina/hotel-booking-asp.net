using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Employee
{
    public interface IEmployeeRepository
    {
        public Task<List<Zaposlenik>> DohvatiZaposlenikeHotela(int hotelId);
    }
}
