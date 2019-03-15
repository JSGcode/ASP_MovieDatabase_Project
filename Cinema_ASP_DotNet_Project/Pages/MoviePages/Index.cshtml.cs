using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cinema_ASP_DotNet_Project.Models;

namespace Cinema_ASP_DotNet_Project.Pages.MoviePages
{
    public class IndexModel : PageModel
    {
        private readonly Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext _context;

        public IndexModel(Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext context)
        {
            _context = context;
        }

        public IList<Movies> Movies { get;set; }

        public async Task OnGetAsync()
        {
            Movies = await _context.Movies
                .Include(m => m.AgeRating)
                .Include(m => m.Director)
                .Include(m => m.Genre)
                .Include(m => m.YearOfRelease).ToListAsync();
        }
    }
}
