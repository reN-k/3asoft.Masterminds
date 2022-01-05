using _3asoft.Masterminds.Core.Entities;
using _3asoft.Masterminds.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Interfaces
{
    public interface IMentorService
    {
        Task<MentorModel> GetMentorAsync(int mentorId);

        Task<List<MentorModel>> GetMentorsAsync(int skip = 0, int take = 20);

        Task<List<ShortDescriptionMentorModel>> GetShortMentorsAsync(int skip = 0, int take = 20);

        Task<bool> AddMentorAsync(MentorModel newMentor);

        Task<bool> RemoveMentorAsync(int mentorId);

        Task<bool> UpdateMentorAsync(MentorModel mentor);
    }
}
