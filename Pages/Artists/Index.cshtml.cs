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
    public class IndexModel : PageModel
    {
        private readonly artfind.Data.ApplicationDbContext _context;

        public IndexModel(artfind.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Artist> Artist { get;set; }

        public async Task OnGetAsync()
        {
            Artist = await _context.Artist.ToListAsync();
        }
    }
}
