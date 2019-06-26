using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using artfind.Data;
using artfind.Models;


namespace artfind.Pages.Art
{
    public class DeleteModel : PageModel
    {
        private readonly artfind.Data.ApplicationDbContext _context;

        public DeleteModel(artfind.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Art Art { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Art = await _context.Art
                .Include(a => a.Artist).FirstOrDefaultAsync(m => m.ArtID == id);

            if (Art == null)
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

            Art = await _context.Art.FindAsync(id);

            if (Art != null)
            {
                _context.Art.Remove(Art);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
