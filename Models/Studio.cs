using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoviePro.Models
{
    public class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime FoundedDate { get; set; }
        public decimal BoxOfficeRevenue { get; set; }

        //Who are my children?
        public virtual ICollection<Movie> Movies{get; set;}
    }
}