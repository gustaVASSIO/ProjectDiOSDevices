using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using ProjectDevice.API.Context;
using ProjectDevice.API.DTO;
using ProjectDevice.API.Middlewares.Exceptions;
using ProjectDevice.API.Models;
using ProjectDevice.API.Repository.Interfaces;

namespace ProjectDevice.API.Repository.Classes
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;

        public SubscriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Insert(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            
        }
        
        public void Update(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
            
        }
        public Task Commit()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<List<Subscription>> FindAllAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var subscription =await _context.Subscriptions.FirstOrDefaultAsync(x => x.SubscriptionId.Equals(id));

            if (subscription == null)
                return false;

            return true;

        }
    }
}
