using _3asoft.Masterminds.Core.Entities;
using _3asoft.Masterminds.Core.Models;
using _3asoft.Masterminds.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Services
{
    public class MentorService : IMentorService
    {
        private IMentorStorage _mentorStorage;

        public MentorService(IMentorStorage mentorStorage)
        {
            _mentorStorage = mentorStorage;
        }

        public async Task<bool> AddMentorAsync(MentorModel newMentor)
        {
            MentorEntity mentorEntity = new MentorEntity
            {
                Name = newMentor.Name,
                Profession = newMentor.Profession,
                Desctiption = newMentor.Desctiption,
                Rate = newMentor.Rate,
                Rating = newMentor.Rating
            };

            await _mentorStorage.AddMentorAsync(mentorEntity);
            return true;
        }

        
        public async Task<MentorModel> GetMentorAsync(int mentorId)
        {
            MentorEntity mentor = await _mentorStorage.GetMentorAsync(mentorId);
            MentorModel mentorModel = new MentorModel
            {
                Id = mentor.Id,
                Name = mentor.Name,
                Profession = mentor.Profession,
                Rating = mentor.Rating,
                Rate = mentor.Rate,
                Desctiption = mentor.Desctiption
                //Reviews = 
                //ProfessionalAspects = 
            };

            return mentorModel;
        }

        public async Task<List<MentorModel>> GetMentorsAsync(int skip = 0, int take = 20)
        {
            List<MentorEntity> entities = await _mentorStorage.GetMentorsAsync(skip, take);
            List<MentorModel> mentors = new List<MentorModel>();

            foreach (var e in entities)
            {
                mentors.Add(new MentorModel
                {
                    Name = e.Name,
                    Profession = e.Profession,
                    Rating = e.Rating,
                    Rate = e.Rate,
                    Desctiption = e.Desctiption
                });
            }

            return mentors;
        }

        public async Task<List<ShortDescriptionMentorModel>> GetShortMentorsAsync(int skip = 0, int take = 20)
        {
            List<MentorEntity> entities = await _mentorStorage.GetMentorsAsync(skip, take);
            List<ShortDescriptionMentorModel> shortMentors = new List<ShortDescriptionMentorModel>();

            foreach (var e in entities)
            {
                shortMentors.Add(new ShortDescriptionMentorModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Profession = e.Profession,
                    Rating = e.Rating
                    // Avatar =
                });
            }

            return shortMentors;
        }

        public async Task<bool> RemoveMentorAsync(int mentorId)
        {
            bool result = await _mentorStorage.RemoveMentorAsync(mentorId);

            return result;
        }

        public async Task<bool> UpdateMentorAsync(MentorModel mentor)
        {
            MentorEntity entity = new MentorEntity
            {
                Name = mentor.Name,
                Profession = mentor.Profession,
                Desctiption = mentor.Desctiption,
                Rate = mentor.Rate,
                Rating = mentor.Rating
            };

            bool result = await _mentorStorage.UpdateMentorAsync(entity);
            return result;
        }
    }

}
