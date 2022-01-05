using _3asoft.Masterminds.Core.Models;
using _3asoft.Masterminds.Interfaces;
using _3asoft.Masterminds.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Controllers
{
    [Route("/")]
    [ApiController]
    public class ShortMentorsController : ControllerBase
    {
        private readonly IMentorService _mentorService;

        public ShortMentorsController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }


        [HttpGet]
        public async Task<List<ShortDescriptionMentorModel>> GetShortMentors(int skip = 0, int take = 20)
        {
            var shortMentors = await _mentorService.GetShortMentorsAsync(skip, take);
            
            return shortMentors;
        }
    }
}
