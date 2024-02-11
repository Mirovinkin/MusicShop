using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    public class PlatesOnSale
    {
        public string PlateName { get; set; } = null!;

        public decimal Price { get; set; }

        public int TrackNumber { get; set; }

        public DateTime SalesDate { get; set; }

    }
}
