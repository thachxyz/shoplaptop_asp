using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Message
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Photo { get; set; }
        public string? Phone { get; set; }
        public string Messagel { get; set; } = null!;
        public DateTime? ReadAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}