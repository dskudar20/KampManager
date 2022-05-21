using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampManager.Classes
{
    public class Guest : Person
    {
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }
    }
}
