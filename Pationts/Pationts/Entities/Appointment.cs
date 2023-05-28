using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pationts.Entities
{
    public class Appointment

    {
        public int Id { get; set; }
        public int Doctor_Id { get; set; }
        public int Pationt_Id { get; set; }
        public string Appointment_time { get; set;}
        public int Confirmed { get; set; }
    }
}
