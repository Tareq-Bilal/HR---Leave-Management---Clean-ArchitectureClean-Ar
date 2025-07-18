using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Excpetions
{
    public class NotFoundExcption : Exception
    {
        public NotFoundExcption(string name , object key) : base($"{name} ({key}) was not found") { 
        
        }
    }
}
