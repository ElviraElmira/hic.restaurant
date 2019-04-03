using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hic.restaurant.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string OpeningHours { get; set; }
        public List<Table> Tables { get; set; }
    }
}
