using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class WrongAccountPasswordException : ApplicationException
    {
        public WrongAccountPasswordException(string message) :base(message) {}
    }
}
