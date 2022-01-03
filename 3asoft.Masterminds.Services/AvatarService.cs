
using _3asoft.Masterminds.Core.Models;
using _3asoft.Masterminds.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Services
{
    public class AvatarService : IAvatar
    {
        public static List<AvatarModel> MentorAvatarsList = new List<AvatarModel>
        {
            new AvatarModel(), //для соответствия ид и номера в листе
            new AvatarModel(1, "1.Zibrov"),
            new AvatarModel(2, "2.Wilde"),
            new AvatarModel(3, "3.Witherspoon"),
            new AvatarModel(4), // Mars
            new AvatarModel(5, "5.Hadid"),
            new AvatarModel(6, "6.Perry"),
            new AvatarModel(7, "7.Portman"),
            new AvatarModel(8, "8.Moore"),
            new AvatarModel(9, "9.Phoenix"),
            new AvatarModel(10, "10.Harington"),
            new AvatarModel(11, "11.Minaj"),
            new AvatarModel(12, "12.Stone")
        };


        public void AddFile()
        {

        }

        public AvatarModel GetPicture(int pictureId)
        {
            if (pictureId <= 0 || pictureId > MentorAvatarsList.Count())
            {
                throw new ArgumentException("Incorrect id");
            }

            return MentorAvatarsList[pictureId];
        }
    }
}
