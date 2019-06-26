using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using artfind.Data;
using artfind.Models;

namespace artfind.Pages.ArtPiece
{
    public class EditModel : PageModel
    {
        private readonly artfind.Data.ApplicationDbContext _context;

        public EditModel(artfind.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public artfind.Models.ArtPiece ArtPiece { get; set; }

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
           ViewData["ArtistID"] = new SelectList(_context.Artist, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ArtPiece).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtPieceExists(ArtPiece.ArtPieceID))
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

        private bool ArtPieceExists(int id)
        {
            return _context.ArtPiece.Any(e => e.ArtPieceID == id);
        }
    }
}
