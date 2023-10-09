using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Notification
    {
        public string Id { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string NotifiableType { get; set; } = null!;
        public string NotifiableId { get; set; }
        public string Data { get; set; } = null!;
        public DateTime? ReadAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}