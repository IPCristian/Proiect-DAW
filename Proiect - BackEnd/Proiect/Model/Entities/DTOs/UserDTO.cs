using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Model.Entities.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Subscription Subscription { get; set; }
        public List<Playlist> Playlists { get; set; }

        public UserDTO(User user)
        {
            this.Id = user.Id;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Subscription = user.Subscription;
            this.Playlists = new List<Playlist>();
        }
    }
}
