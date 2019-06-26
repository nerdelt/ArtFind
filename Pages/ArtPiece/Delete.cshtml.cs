using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using artfind.Data;
using artfind.Models;

namespace artfind.Pages.ArtPiece
{
    public class DeleteModel : PageModel
    {
        private readonly artfind.Data.ApplicationDbContext _context;

        public DeleteModel(artfind.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ArtPiece ArtPiece { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ArtPiece = await _context.ArtPiece
                .Include(a => a.Artist).FirstOrDefaultAsync(m => m.ArtPieceID == id);

            if (ArtPiece == null)
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

            ArtPiece = await _context.ArtPiece.FindAsync(id);

            if (ArtPiece != null)
            {
                _context.ArtPiece.Remove(ArtPiece);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
