using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Deal
    {
        public long Id { get; set; }
        public decimal Sale {get;set;}

        public DateTime? Starts {get;set;}
        public DateTime? Ends {get;set;}
        public DateTime? CreatedAt {get;set;}
        
        public DateTime? UpdateAt {get;set;}

    }
}