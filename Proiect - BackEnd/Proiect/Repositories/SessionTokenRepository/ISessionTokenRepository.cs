using Proiect.Model.Entities;
using Proiect.Repositories.GenericRepository2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories.SessionTokenRepository
{
    public interface ISessionTokenRepository : IGenericRepository2<SessionToken>
    {
        Task<SessionToken> GetByJTI(string jti);
    }
}
