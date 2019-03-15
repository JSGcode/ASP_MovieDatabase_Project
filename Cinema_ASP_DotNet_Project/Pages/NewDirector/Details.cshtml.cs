using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cinema_ASP_DotNet_Project.Models;

namespace Cinema_ASP_DotNet_Project.Pages.NewDirector
{
    public class DetailsModel : PageModel
    {
        private readonly Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext _context;

        public DetailsModel(Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext context)
        {
            _context = context;
        }

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
    }
}
