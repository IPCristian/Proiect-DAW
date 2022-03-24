using Proiect.Model.Entities;
using Proiect.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories.SubscriptionRepository
{
    public interface ISubscriptionRepository : IGenericRepository2<Subscription>
    {
        Task<Subscription> GetByUserId(int id);
        Task<Subscription> GetById(int id);
        Task<List<Subscription>> GetAllSubs();
        Task<User> GetUserData(int id);
        Task<List<SubsWithUser>> GetAllSubsFromUsers(string lastName);
    }
}
