using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Model.Entities.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Genre { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; }

        public SongDTO(Song song)
        {
            this.Id = song.Id;
            this.Name = song.Name;
            this.ArtistName = song.ArtistName;
            this.Genre = song.Genre;
            this.PlaylistSongs = new List<PlaylistSong>();
        }
    }
}
