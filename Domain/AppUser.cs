using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string AuthProviderId { get; set; }
    }
}