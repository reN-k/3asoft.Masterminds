using _3asoft.Masterminds.Core.Models;
using _3asoft.Masterminds.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _3asoft.Masterminds.Controllers
{
    [Route("/")]
    [ApiController]
    public class AllMentorsController : ControllerBase
    {
        [HttpGet]
        public List<ShortDescriptionMentorModel> GetAllMentors()
        {
            MentorService service = new MentorService();
            service.SetAllAvatars();

            List<ShortDescriptionMentorModel> mentors = service.GetAllMentorsShortInfo();

            return mentors;
        }
    }
}
