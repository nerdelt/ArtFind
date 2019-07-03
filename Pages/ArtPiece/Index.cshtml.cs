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
        public string TitleSort { get; set; }
        public string DateSort { get; set; }
        public string LocationSort { get; set; }
        public string ArtistSort { get; set; }
        public string DimSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<artfind.Models.ArtPiece> ArtPiece { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString) //int? pageIndex, string currentFilter,)
        {
            //CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ArtistSort = sortOrder == "Artist" ? "artist_desc" : "Artist";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            LocationSort = sortOrder == "Location" ? "loc_desc" : "Location";
            DimSort = sortOrder == "Dimensions" ? "dim_desc" : "Dimensions";

           /* if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }*/

            CurrentFilter = searchString;

          
            var artPieceIQ = from s in _context.ArtPiece
                                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                artPieceIQ = artPieceIQ.Where(s => s.Title.Contains(searchString)
                                       || s.Artist.LastName.Contains(searchString)
                                       || s.Artist.FirstName.Contains(searchString)
                                       || s.CurrentLocation.Contains(searchString)
                                       || s.Medium.Contains(searchString)
                                       || s.YearCreated.Equals(searchString));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    artPieceIQ = artPieceIQ.OrderByDescending(s => s.Title);
                    break;
                case "artist_desc":
                    artPieceIQ = artPieceIQ.OrderByDescending(s => s.Artist.LastName);
                    break;
                case "Artist":
                    artPieceIQ = artPieceIQ.OrderBy(s => s.Artist.LastName);
                    break;
                case "Date":
                    artPieceIQ = artPieceIQ.OrderBy(s => s.YearCreated);
                    break;
                case "date_desc":
                    artPieceIQ = artPieceIQ.OrderByDescending(s => s.YearCreated);
                    break;
                case "loc_desc":
                    artPieceIQ = artPieceIQ.OrderByDescending(s => s.CurrentLocation);
                    break;
                case "Location":
                    artPieceIQ = artPieceIQ.OrderBy(s => s.CurrentLocation);
                    break;
                case "dim_desc":
                    artPieceIQ = artPieceIQ.OrderByDescending(s => s.Height);
                    break;
                case "Dimensions":
                    artPieceIQ = artPieceIQ.OrderBy(s => s.Height);
                    break;
                default:
                    artPieceIQ = artPieceIQ.OrderBy(s => s.Title);
                    break;
            }


            //int pageSize = 3;

            ArtPiece = await artPieceIQ.AsNoTracking()
                 .Include(a => a.Artist).ToListAsync();

        }
    }
 }

