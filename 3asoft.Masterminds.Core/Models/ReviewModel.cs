using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3asoft.Masterminds.Core.Models
{
    public class ReviewModel
    {
        public int Id { get; set; } 
        public string AuthorName { get; set; }
        public string Photo { get; set; }
        public string Text { get; set; } 
        public double Rating { get; set; }

        public static int ReviewCount = 0;

        public ReviewModel(double _rating)
        {
            Id = ++ReviewCount;
            AuthorName = $"Ivan{_rating} Ivanov";
            Photo = $"{_rating}.jpg";
            Text = $"{_rating}+{_rating}+{_rating}";
            Rating = _rating;
        }
    }
}
