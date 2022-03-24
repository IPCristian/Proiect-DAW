using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Model.Entities.DTOs
{
    public class CreateSubDTO
    {
        public int UserId { get; set; }

        public User User { get; set; }

    }
}
