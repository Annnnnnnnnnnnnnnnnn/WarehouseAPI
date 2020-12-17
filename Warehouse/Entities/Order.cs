using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Amount { get; set; }
    }
}
