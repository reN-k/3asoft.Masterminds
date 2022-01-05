using _3asoft.Masterminds.Core.Entities;
using _3asoft.Masterminds.Core.Models;
using _3asoft.Masterminds.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Data
{
    public class MentorStorage : IMentorStorage
    {
        private MastermindsDbContext _db;

        public MentorStorage(MastermindsDbContext dbContext)
        {
            _db = dbContext;
        }


        public async Task<MentorEntity> GetMentorAsync(int mentorId)
        {
            MentorEntity mentor = await _db.Mentors.FirstOrDefaultAsync(m => m.Id == mentorId);  

            MentorEntity m = await _db.Mentors.FindAsync(mentorId);

            return m;
        }

        public async Task<List<MentorEntity>> GetMentorsAsync(int skip = 0, int take = 20)
        {
            List<MentorEntity> mentors = await _db.Mentors.Skip(skip).Take(take).ToListAsync();
            
            return mentors;
        }

        public async Task<bool> AddMentorAsync(MentorEntity newMentor)
        {
            _db.Mentors.Add(newMentor);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveMentorAsync(int mentorId)
        {
            MentorEntity mentor = _db.Mentors.First(m => m.Id == mentorId);

            if (mentor == null)
            {
                return false;
            }

            _db.Mentors.Remove(mentor);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateMentorAsync(MentorEntity newMentor)
        {
            _db.Mentors.Update(newMentor);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
