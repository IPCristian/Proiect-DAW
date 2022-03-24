using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Model.Entities;
using Proiect.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Repositories.SubscriptionRepository
{
    public class SubscriptionRepository : GenericRepository2<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(AuthentificationContext context) : base(context) { }

        public async Task<Subscription> GetById(int id)
        {
            return await _context.Subscriptions.Where(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Subscription> GetByUserId(int id)
        {
            return await _context.Subscriptions.Where(a => a.UserId.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Subscription>> GetAllSubs()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<User> GetUserData(int id)
        {
            return await _context.MUsers.Where(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<SubsWithUser>> GetAllSubsFromUsers(string lastName) // Get all subs from users whose last name is equal to the specified one
        {
            var result = _context.Subscriptions.Join(
                                                    _context.MUsers,
                                                    Subscription => Subscription.UserId,
                                                    User => User.Id,
                                                    (subscription, user) => new SubsWithUser()
                                                    {
                                                        User = user,
                                                        Sub = subscription
                                                    }).Where(subscriptionAndUser => subscriptionAndUser.User.LastName == lastName).ToListAsync();

            return await result;
        } 
    }
}
