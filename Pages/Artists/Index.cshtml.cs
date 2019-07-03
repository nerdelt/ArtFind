using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using artfind.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Artist> artists = from a in _context.Artist
                         select a;

            if (!string.IsNullOrEmpty(SearchString))
            {
                artists = artists.Where//(s => s.LastName.Contains(SearchString)
                //|| s.FirstName.Contains(SearchString)
                //||
                (s => s.LastName.Contains(SearchString) && s.FirstName.Contains(SearchString));
                //|| s.Nationality.Contains(SearchString));
            }

            Artist = await artists.ToListAsync();
        }
    }
}
