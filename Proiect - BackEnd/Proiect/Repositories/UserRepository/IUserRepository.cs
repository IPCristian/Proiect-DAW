using Proiect.Model.Entities;
using Proiect.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository2<User>
    {
        Task<User> GetById(int id);
        Task<List<User>> GetAllUsers();
        Task<List<GroupPlaylist>> GetUserPlaylistCount();
    }
}