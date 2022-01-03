using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Core.Models
{
    public class AvatarModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Anonim";
        public static string Path { get; set; } = "C:/Users/ojiek/source/repos/3asoft/3asoft.Masterminds.Data/Portrets/";

        public AvatarModel() { }

        /// <summary>
        /// Создание аккаунта без портрета
        /// </summary>
        /// <param name="_id"> ид аватара == ид ментора </param>
        public AvatarModel(int _id)
        {
            Id = _id;
        } 

        public AvatarModel(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }
    }
}
