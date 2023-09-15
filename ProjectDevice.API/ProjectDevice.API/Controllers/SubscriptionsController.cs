using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectDevice.API.DTO;
using ProjectDevice.API.Models;
using ProjectDevice.API.Repository.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace ProjectDevice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public SubscriptionsController(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Subscription>>> GetSusbscriptions()
        {
            var subscrioptions = await _subscriptionRepository.FindAllAsync();
            return Ok(subscrioptions);
        }

        [HttpPost]
        public async Task<ActionResult> PostSubscriptions(List<SubscriptionCreatedDTO> subscriptionsDto)
        {
            foreach (var subs in subscriptionsDto)
            {
                var subscription = new Subscription()
                {
                    Title = subs.Title,
                    Description = subs.Description,
                    DeviceId = subs.DeviceId
                };
                _subscriptionRepository.Insert(subscription);
            }
            await _subscriptionRepository.Commit();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutSubscriptions(List<SubscriptionDto> subscriptionsDto)
        {
            foreach (var subs in subscriptionsDto)
            {
                Subscription subscription = _mapper.Map<Subscription>(subs);

                _subscriptionRepository.Update(subscription);
            }
            await _subscriptionRepository.Commit();

            return Ok();
        }
    }
}
