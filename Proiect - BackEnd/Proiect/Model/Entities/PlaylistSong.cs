using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Model.Entities
{
    public class PlaylistSong
    {
        public Playlist Playlist { get; set; }
        public int PlaylistId { get; set; }
        public Song Song { get; set; }
        public int SongId { get; set; }
    }
}