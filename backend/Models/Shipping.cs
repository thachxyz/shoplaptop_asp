using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Shipping
    {
        public long Id { get; set; }
        public string Type { get; set; } = null!;
        public decimal Price { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? CreateAt { get; set; }
        public virtual ICollection<Order> Orders { get; } = new List<Order>();
    }
}