using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Model.Entities.DTOs
{
    public class CreateSongDTO
    {
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Genre { get; set; }

    }
}
