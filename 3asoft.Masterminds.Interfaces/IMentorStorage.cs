using _3asoft.Masterminds.Core.Entities;
using _3asoft.Masterminds.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Interfaces
{
    public interface IMentorStorage
    {
        Task<MentorEntity> GetMentorAsync(int mentorId);

        Task<List<MentorEntity>> GetMentorsAsync(int skip = 0, int take = 20);

        Task<bool> AddMentorAsync(MentorEntity newMentor);

        Task<bool> RemoveMentorAsync(int mentorId);

        Task<bool> UpdateMentorAsync(MentorEntity newMentor);
    }
}
