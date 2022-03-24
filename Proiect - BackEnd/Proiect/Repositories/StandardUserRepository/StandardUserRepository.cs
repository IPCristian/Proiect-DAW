using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Model.Entities;
using Proiect.Repositories.GenericRepository2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories.StandardUserRepository
{
    public class StandardUserRepository : GenericRepository2<StandardUser>, IStandardUserRepository
    {
        public StandardUserRepository(AuthentificationContext context) : base(context) { }
        public async Task<List<StandardUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<StandardUser> GetByIdWithRoles(int id)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task<StandardUser> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

    }
}
