using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Model.Entities.DTOs
{
    public class SubDTO
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public SubDTO(Subscription sub)
        {
            this.Id = sub.Id;
            this.User = sub.User;
            this.UserId = sub.UserId;
        }
    }
}
