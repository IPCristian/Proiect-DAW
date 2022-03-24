using Proiect.Repositories.SessionTokenRepository;
using Proiect.Repositories.StandardUserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        IStandardUserRepository StandardUser { get; }
        ISessionTokenRepository SessionToken { get; }
        Task SaveAsync();
    }
}
