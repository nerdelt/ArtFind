using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using artfind.Data;
using artfind.Models;


namespace artfind.Pages.Art
{
    public class CreateModel : PageModel
    {
        private readonly artfind.Data.ApplicationDbContext _context;

        public CreateModel(artfind.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ArtistID"] = new SelectList(_context.Artist, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Art Art { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Art.Add(Art);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}