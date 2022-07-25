using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Web_API.Entities
{
    public class Account : IdentityUser
    {
        public int? StudentId { get; set; }
        public Student Student { get; set; }
    }
}
