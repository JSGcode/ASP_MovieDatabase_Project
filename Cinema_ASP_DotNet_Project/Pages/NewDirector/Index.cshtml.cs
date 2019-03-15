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
    public class IndexModel : PageModel
    {
        private readonly Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext _context;

        public IndexModel(Cinema_ASP_DotNet_Project.Models.Cinema_ASP_DotNet_ProjectContext context)
        {
            _context = context;
        }

        public IList<Director> Director { get;set; }

        public async Task OnGetAsync()
        {
            Director = await _context.Director.ToListAsync();
        }
    }
}
