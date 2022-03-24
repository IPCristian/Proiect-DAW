using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Model.Entities
{
    public class SubsWithUser  // Used for the join 
    {
        public User User { get; set; }
        public Subscription Sub { get; set; }
    }
}
