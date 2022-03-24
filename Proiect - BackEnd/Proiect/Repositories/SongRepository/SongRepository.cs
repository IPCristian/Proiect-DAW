using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Model.Entities;
using Proiect.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories.SongRepository
{
    public class SongRepository : GenericRepository2<Song>, ISongRepository
    {
        public SongRepository(AuthentificationContext context) : base(context) { }

        public async Task<List<Song>> GetAllSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<Song> GetById(int id)
        {
            return await _context.Songs.Where(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Song>> GetSongsFromArtist(string artistName)  
        {
            return await _context.Songs.Where(a => a.ArtistName.Equals(artistName)).Include(a => a.PlaylistSongs).ToListAsync();
        }
    }
}
