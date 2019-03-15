using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_ASP_DotNet_Project.Models
{
    [Table("DirectorsTable")]
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        public string TheDirectors { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
