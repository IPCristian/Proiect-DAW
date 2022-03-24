using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Model.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}