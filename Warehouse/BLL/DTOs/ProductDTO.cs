using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Cost { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
    }
}
