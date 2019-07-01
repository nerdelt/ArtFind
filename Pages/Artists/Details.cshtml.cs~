using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using artfind.Models;

namespace artfind.Pages.Artists
{
    public class DetailsModel : PageModel
    {
        private readonly artfind.Data.ApplicationDbContext _context;

        public DetailsModel(artfind.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Artist Artist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = await _context.Artist
                 .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Artist == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
