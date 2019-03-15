using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_ASP_DotNet_Project.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Genres { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
