using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect.Model.Entities;
using Proiect.Model.Entities.DTOs;
using Proiect.Repositories.SubscriptionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository _repository;

        public SubscriptionController(ISubscriptionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllSubs()
        {
            var allsubs = await _repository.GetAllSubs();

            var subsToReturn = new List<SubDTO>();

            foreach (var sub in allsubs)
            {
                subsToReturn.Add(new SubDTO(sub));
            }

            return Ok(subsToReturn);
        }

        [HttpGet("{lastName}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllSubsFromUsers(string lastName)
        {
            var allsubs = await _repository.GetAllSubsFromUsers(lastName);

            return Ok(allsubs);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSubscription(CreateSubDTO dto)
        {
            Subscription newSub = new Subscription();

            newSub.UserId = dto.UserId;

            _repository.Create(newSub);

            await _repository.SaveAsync();

            return Ok(new SubDTO(newSub));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateSubId(int subId, int newId) 
        {
            var sub = await _repository.GetById(subId);

            if (sub == null)
            {
                return NotFound("The speficied ID isn't attributed to any of the subscriptions");
            }

            sub.Id = newId;

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSubById(int id)
        {
            var sub = await _repository.GetById(id);

            if (sub == null)
            {
                return NotFound("The speficied ID isn't attributed to any of the subscriptions");
            }

            _repository.Delete(sub);

            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
