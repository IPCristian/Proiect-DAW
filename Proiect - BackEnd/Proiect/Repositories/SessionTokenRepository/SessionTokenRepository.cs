using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Model.Entities;
using Proiect.Repositories.GenericRepository2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories.SessionTokenRepository
{
    public class SessionTokenRepository : GenericRepository2<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(AuthentificationContext context) : base(context) { }

        public async Task<SessionToken> GetByJTI(string jti)
        {
            return await _context.SessionTokens.FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}
