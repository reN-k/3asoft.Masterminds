using _3asoft.Masterminds.Core.Entities;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Data
{
    public static class RandomDataSeeder
    {
        public static List<MentorEntity> CreateFakeMentors (int quantity)
        {
            int id = 1;

            var fakeMentors = new Faker<MentorEntity>()
                .CustomInstantiator(f => new MentorEntity { Id = id++ })
                .RuleFor(m => m.Name, f => f.Name.FullName())
                .RuleFor(m => m.Profession, f => f.Lorem.Word())
                .RuleFor(m => m.Rate, f => f.Random.Double(16.20, 120))
                .RuleFor(m => m.Rating, f => f.Random.Double(0, 10))
                .RuleFor(m => m.Desctiption, f => f.Lorem.Lines());


            return fakeMentors.Generate(quantity);
        }
    }
}
