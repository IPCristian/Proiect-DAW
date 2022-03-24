using Microsoft.EntityFrameworkCore;
using Proiect.Controllers;
using Proiect.Data;
using Proiect.Model.Entities;
using Proiect.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories.UserRepository
{
    public class UserRepository : GenericRepository2<User>, IUserRepository
    {
        public UserRepository(AuthentificationContext context) : base(context) { }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.MUsers.Include(u => u.Playlists).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.MUsers.Where(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<GroupPlaylist>> GetUserPlaylistCount() // Get the number of playlists for each user
        {
            var result = from u in _context.MUsers
                         group u.Playlists by u.Id into p
                         select new GroupPlaylist()
                         {
                             userId = p.Key,
                             count = p.Count()
                         };

            return await result.ToListAsync(); ;
        }

    }
}
