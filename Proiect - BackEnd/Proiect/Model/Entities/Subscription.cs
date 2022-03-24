using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proiect.Model.Entities
{
    public class Subscription 
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}