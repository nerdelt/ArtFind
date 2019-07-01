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
    public class DetailsModel : PageModel
    {
        private readonly artfind.Data.ApplicationDbContext _context;

        public DetailsModel(artfind.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public artfind.Models.ArtPiece ArtPiece { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ArtPiece = await _context.ArtPiece
                .Include(a => a.Artist)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ArtPieceID == id);

            if (ArtPiece == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
