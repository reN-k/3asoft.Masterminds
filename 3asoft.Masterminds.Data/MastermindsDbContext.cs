using _3asoft.Masterminds.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Data
{
    public class MastermindsDbContext : DbContext
    {
        public DbSet<MentorEntity> Mentors { get; set; }

        public MastermindsDbContext(DbContextOptions<MastermindsDbContext> options)
            : base(options) { }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            OnMentorModelCreating(modelBuilder);

            SeedFakeData(modelBuilder);
        }

        private void OnMentorModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MentorEntity>().ToTable("Mentors");
            modelBuilder.Entity<MentorEntity>().HasKey(m => m.Id);
            //modelBuilder.Entity<MentorEntity>().

            modelBuilder.Entity<MentorEntity>()
                .Property(m => m.Name)
                .IsRequired();

            modelBuilder.Entity<MentorEntity>()
                .Property(m => m.Profession)
                .IsRequired();

            modelBuilder.Entity<MentorEntity>()
                .Property(m => m.Rate)
                .IsRequired();

            modelBuilder.Entity<MentorEntity>()
                .Property(m => m.Rating)
                .IsRequired();

            modelBuilder.Entity<MentorEntity>()
                .Property(m => m.Desctiption)
                .IsRequired();
        }

        private void SeedFakeData(ModelBuilder modelBuilder)
        {
            SeedFakeMentors(modelBuilder, 100); // количество менторов
        }

        private void SeedFakeMentors(ModelBuilder modelBuilder, int quantity)
        {
            var fakeMentors = RandomDataSeeder.CreateFakeMentors(quantity);

            foreach (var fakeM in fakeMentors)
            {
                modelBuilder.Entity<MentorEntity>().HasData(fakeM);
            }
            
        }
    }
}
