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
    public class DeleteModel : PageModel
    {
        private readonly Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext _context;

        public DeleteModel(Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movies Movies { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movies = await _context.Movies
                .Include(m => m.AgeRating)
                .Include(m => m.Director)
                .Include(m => m.Genre)
                .Include(m => m.YearOfRelease).FirstOrDefaultAsync(m => m.MovieId == id);

            if (Movies == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movies = await _context.Movies.FindAsync(id);

            if (Movies != null)
            {
                _context.Movies.Remove(Movies);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
