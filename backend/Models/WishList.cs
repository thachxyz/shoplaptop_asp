using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class WishList
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long? CartId { get; set; }
        public long? UserId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual Cart? Cart { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual User? User { get; set; }
    }
}