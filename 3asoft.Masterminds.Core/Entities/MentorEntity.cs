using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Core.Entities
{
    public class MentorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public double Rate { get; set; }
        public double Rating { get; set; }
        public string Desctiption { get; set; }



        //public AvatarModel Avatar { get; set; }
        //public List<string> ProfessionalAspects { get; set; }
        //public ReviewModel[] Reviews { get; set; }
    }
}
