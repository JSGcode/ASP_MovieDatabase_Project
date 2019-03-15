using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema_ASP_DotNet_Project.Models;

namespace Cinema_ASP_DotNet_Project.Pages.MoviePages
{
    public class EditModel : PageModel
    {
        private readonly Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext _context;

        public EditModel(Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext context)
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
           ViewData["AgeRatingId"] = new SelectList(_context.Set<AgeRating>(), "AgeRatingId", "Rating");
           ViewData["DirectorId"] = new SelectList(_context.Set<Director>(), "DirectorId", "TheDirectors");
           ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "Genres");
           ViewData["YearOfReleaseId"] = new SelectList(_context.Set<YearOfRelease>(), "YearOfReleaseId", "Year");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Movies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(Movies.MovieId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MoviesExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
