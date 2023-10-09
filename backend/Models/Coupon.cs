using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public partial class Coupon
    {
        public long Id { get; set; }
        public string Code { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal Value { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}