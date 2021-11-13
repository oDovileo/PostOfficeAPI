using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostOfficeAPI.Entities
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public int Capacity { get; set; }        
        public string Code { get; set; }
        public List<ParcelModel> Parcels { get; set; }
    }
}
