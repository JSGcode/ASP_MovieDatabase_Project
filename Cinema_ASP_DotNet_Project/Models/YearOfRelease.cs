using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_ASP_DotNet_Project.Models
{
    [Table("Year Of Release")]
    public class YearOfRelease
    {
        [Key]
        public int YearOfReleaseId { get; set; }
        public string Year { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
