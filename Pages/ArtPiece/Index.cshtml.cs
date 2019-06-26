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
    public class IndexModel : PageModel
    {
        private readonly artfind.Data.ApplicationDbContext _context;

        public IndexModel(artfind.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ArtPiece> ArtPiece { get;set; }

        public async Task OnGetAsync()
        {
            ArtPiece = await _context.ArtPiece
                .Include(a => a.Artist).ToListAsync();
        }
    }
}
