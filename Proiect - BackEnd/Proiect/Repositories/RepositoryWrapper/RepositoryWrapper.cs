using Proiect.Data;
using Proiect.Repositories.SessionTokenRepository;
using Proiect.Repositories.StandardUserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AuthentificationContext _context;
        private IStandardUserRepository _user;
        private ISessionTokenRepository _sessionToken;
        public RepositoryWrapper(AuthentificationContext context)
        {
            _context = context;
        }

        public IStandardUserRepository StandardUser
        {
            get
            {
                if (_user == null)
                {
                    _user = new StandardUserRepository.StandardUserRepository(_context);
                }
                return _user;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null)
                {
                    _sessionToken = new SessionTokenRepository.SessionTokenRepository(_context);
                }

                return _sessionToken;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
