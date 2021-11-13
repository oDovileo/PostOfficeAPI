using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostOfficeAPI.Entities
{
    public class ParcelModel
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }     
        public decimal Weight { get; set; }
        public string Phone { get; set; }
        public int? PostId { get; set; }
    }
}
