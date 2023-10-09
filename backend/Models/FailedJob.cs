using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public partial class FailedJob
    {
        public long Id { get; set; }
        public string Connection { get; set; } = null!;
        public string Queue { get; set; } = null!;
        public string Payload { get; set; } = null!;
        public string Exception { get; set; } = null!;
        public DateTime FailedAt { get; set; }
    }
}