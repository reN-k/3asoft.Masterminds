using _3asoft.Masterminds.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Interfaces
{
    public interface IMentor
    {
        MentorModel GetMentorProfile(int _id);
    }
}
