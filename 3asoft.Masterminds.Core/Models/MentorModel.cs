using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Core.Models
{
    public class MentorModel
    {
        public int Id { get; set; }

        public AvatarModel Avatar { get; set; }

        //public string Photo { get; set; }

        public string Name { get; set; }
        public string Profession { get; set; }
        public double Rating { get; set; } = 0;
        public double Rate { get;set; } 
        public List<string> ProfessionalAspects { get; set; }   
        public string Desctiption { get; set; }
        public ReviewModel[] Reviews { get; set; }



        public MentorModel() { }

        //public MentorModel(int _id, string _name, string _profession, double _rate, 
        //    List<string> _professionalAspects, string _description, params ReviewModel[] _reviews)
        //{
        //    Id = _id;
        //    Avatar = new AvatarModel(Id);
        //    //Photo = _photo;
        //    Name = _name;
        //    Profession = _profession;
        //    Rate = _rate;
        //    ProfessionalAspects = _professionalAspects;
        //    Desctiption = _description;
        //    Reviews = _reviews;


        //    if (_reviews.Length > 0)
        //    {
        //        double sum = 0;

        //        for (int i = 0; i < _reviews.Length; i++)
        //        {
        //            sum += _reviews[i].Rating;
        //        }
        //        Rating = Math.Round ( sum / _reviews.Length, 2); //округляем до 2х знаков
        //    }
               
        //}

        //public void SetAvatar(AvatarModel _avatar)
        //{
        //    this.Avatar = _avatar;
        //}
    }
}
