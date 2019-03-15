using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_ASP_DotNet_Project.Models
{
    [Table("AgeRatingTable")]
    public class AgeRating
    {
        [Key]
        public int AgeRatingId { get; set; }
        public string Rating { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
