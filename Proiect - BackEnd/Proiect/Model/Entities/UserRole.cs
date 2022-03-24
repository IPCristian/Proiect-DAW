using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Model.Entities
{
    public class UserRole : IdentityUserRole<int>
    {
        public Role Role { get; set; }
        public StandardUser StandardUser { get; set; }
    }
}
