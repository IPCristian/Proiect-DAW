using Proiect.Model.Entities;
using Proiect.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories.SongRepository
{
    public interface ISongRepository : IGenericRepository2<Song>
    {
        Task<Song> GetById(int id);
        Task<List<Song>> GetAllSongs();
        Task<List<Song>> GetSongsFromArtist(string artistName);
    }
}
