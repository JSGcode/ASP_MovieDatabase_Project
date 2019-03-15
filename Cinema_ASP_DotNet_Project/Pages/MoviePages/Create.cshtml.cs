using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cinema_ASP_DotNet_Project.Models;

namespace Cinema_ASP_DotNet_Project.Pages.MoviePages
{
    public class CreateModel : PageModel
    {
        private readonly Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext _context;

        public CreateModel(Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AgeRatingId"] = new SelectList(_context.Set<AgeRating>(), "AgeRatingId", "Rating");
        ViewData["DirectorId"] = new SelectList(_context.Set<Director>(), "DirectorId", "TheDirectors");
        ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "Genres");
        ViewData["YearOfReleaseId"] = new SelectList(_context.Set<YearOfRelease>(), "YearOfReleaseId", "Year");
            return Page();
        }

        [BindProperty]
        public Movies Movies { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movies.Add(Movies);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}