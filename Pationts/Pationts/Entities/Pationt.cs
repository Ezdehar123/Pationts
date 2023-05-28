using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pationts.Entities
{
    public class Pationt
    {
        internal int Pationt_Id;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNum { get; set; }
        public int Doctor_Id { get; set; }
    }

    

    
}