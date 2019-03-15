using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema_ASP_DotNet_Project.Models;

namespace Cinema_ASP_DotNet_Project.Pages.NewDirector
{
    public class EditModel : PageModel
    {
        private readonly Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext _context;

        public EditModel(Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Director Director { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Director = await _context.Director.FirstOrDefaultAsync(m => m.DirectorId == id);

            if (Director == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Director).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(Director.DirectorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../MoviePages/Index");
        }

        private bool DirectorExists(int id)
        {
            return _context.Director.Any(e => e.DirectorId == id);
        }
    }
}
