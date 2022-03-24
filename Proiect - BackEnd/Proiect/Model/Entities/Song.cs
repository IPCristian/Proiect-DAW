using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Model.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Genre { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}