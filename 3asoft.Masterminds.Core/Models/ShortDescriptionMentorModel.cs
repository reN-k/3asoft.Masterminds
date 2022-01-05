using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Core.Models
{
    public class ShortDescriptionMentorModel
    {
        public int Id { get; set; }
        //public string Photo { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public double Rating { get; set; }
        public AvatarModel Avatar { get; set; }

        //public ShortDescriptionMentorModel(int _id, string _photo, string _name, string _profession, double _rating)
        //{
        //    Id = _id; 
        //    Photo = _photo;
        //    Name = _name;
        //    Profession = _profession;
        //    Rating = _rating;
        //}

        //public ShortDescriptionMentorModel(int _id, AvatarModel _avatar, string _name, string _profession, double _rating)
        //{
        //    Id = _id;
        //    Name = _name;
        //    Profession = _profession;
        //    Rating = _rating;
        //    Avatar = _avatar;
        //}
    }
}
