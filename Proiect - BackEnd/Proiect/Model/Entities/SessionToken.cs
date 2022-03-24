using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Model.Entities
{
    public class SessionToken
    {
        public SessionToken() { }
        public SessionToken(string jti, int userId, DateTime expirationDate)
        {
            this.Jti = jti;
            this.UserId = userId;
            this.ExpirationDate = expirationDate;
        }

        [Key]
        public string Jti { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
        public StandardUser User { get; set; }
    }
}
