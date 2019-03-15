using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cinema_ASP_DotNet_Project.Models;

namespace Cinema_ASP_DotNet_Project.Models
{
    public class Cinema_ASP_DotNet_ProjectContext : DbContext
    {
        public Cinema_ASP_DotNet_ProjectContext (DbContextOptions<Cinema_ASP_DotNet_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Cinema_ASP_DotNet_Project.Models.Movies> Movies { get; set; }

        public DbSet<Cinema_ASP_DotNet_Project.Models.Director> Director { get; set; }
    }
}
