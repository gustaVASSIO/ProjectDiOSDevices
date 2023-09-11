using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ProjectDevice.API.DTO;
using ProjectDevice.API.Models;

namespace ProjectDevice.API.Repository.Interfaces
{
    public interface ISubscriptionRepository
    {
        void Insert(Subscription subscription);
        void Update(Subscription subscription);
        Task Commit();
    }
}
