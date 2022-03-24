using Proiect.Model.Entities;
using Proiect.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories.StandardUserRepository
{
    public interface IStandardUserRepository : IGenericRepository2<StandardUser>
    {
        Task<List<StandardUser>> GetAllUsers();
        Task<StandardUser> GetUserByEmail(string email);
        Task<StandardUser> GetByIdWithRoles(int id);

    }
}
