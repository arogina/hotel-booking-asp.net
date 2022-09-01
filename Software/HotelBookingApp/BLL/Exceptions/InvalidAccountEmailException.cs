using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class InvalidAccountEmailException : ApplicationException
    {
        public InvalidAccountEmailException(string message) : base(message) {}
    }
}
