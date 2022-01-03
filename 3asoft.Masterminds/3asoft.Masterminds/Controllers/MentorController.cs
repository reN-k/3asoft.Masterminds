using _3asoft.Masterminds.Core.Models;
using _3asoft.Masterminds.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace _3asoft.Masterminds.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        [HttpGet("{id}")]
        public MentorModel ShowMentor(int id)
        {
            MentorService mentorService = new MentorService();
            mentorService.SetAllAvatars();

            return mentorService.GetMentorProfile(id);
        }
    }
}
