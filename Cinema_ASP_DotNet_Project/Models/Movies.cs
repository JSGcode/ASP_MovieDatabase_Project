using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_ASP_DotNet_Project.Models
{
    [Table("MovieTable")]
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }

        // Foreign Keys are implemented the following way
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int YearOfReleaseId { get; set; }
        public YearOfRelease YearOfRelease { get; set; }

        public int AgeRatingId { get; set; }
        public AgeRating AgeRating { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
