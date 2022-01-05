using _3asoft.Masterminds.Core.Models;
using _3asoft.Masterminds.Interfaces;
using _3asoft.Masterminds.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly IMentorService _mentorService;

        public MentorController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        [HttpGet("{id}")]
        public async Task<MentorModel> ShowMentor(int id)
        {
            var mentorEntity = await _mentorService.GetMentorAsync(id);
            MentorModel mentor = new MentorModel
            {
                Id = mentorEntity.Id,
                Name = mentorEntity.Name,
                Profession = mentorEntity.Profession,
                Rating = mentorEntity.Rating,
                Rate = mentorEntity.Rate,
                Desctiption = mentorEntity.Desctiption
            };


            return mentor;            
        }
    }
}
