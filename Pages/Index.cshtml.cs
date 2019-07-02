using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using artfind.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace artfind.Pages
{
    public class IndexModel : PageModel
    {
        private readonly artfind.Data.ApplicationDbContext _context;

        public IndexModel(artfind.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Artist> Artist { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public string CurrentFilter { get; set; }


        public async Task OnGetAsync()
        {
            CurrentFilter = SearchString;

            var artists = from a in _context.Artist
                          select a;

            if (!string.IsNullOrEmpty(SearchString))
            {
                artists = artists.Where(s => s.LastName.Contains(SearchString)
                || s.FirstName.Contains(SearchString)
                || s.Nationality.Contains(SearchString));
            }

            Artist = await artists.ToListAsync();
        }
    }
}

