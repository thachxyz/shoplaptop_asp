using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public partial class PasswordRest
    {
        public long Id {get;set;}
        public string Email {get;set;}
        public string token {get;set;}
        public DateTime? CreatedAt{get;set;}
        public DateTime? UpdateAt{get;set;}
        
    }
}