using System;
using System.ComponentModel.DataAnnotations;

namespace artfind.Models
{
    public class ArtPiece
    {
       public int ArtPieceID { get; set; }

        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Title { get; set; }

       public int ArtistID { get; set; }

       public Artist Artist { get; set; }
      
       [Display(Name = "Year Created")]
       public int YearCreated { get; set; }

       public double Height { get; set; }

       public double Width { get; set; }

       public string Dimensions
        {
            get
            {
                return $"{Height} cm x {Width} cm";
            }
        }


       public string Medium { get; set; }

       [Display(Name = "Current Location")]
       public string CurrentLocation{ get; set; }



       //public Current Location
       //photo of work

    }
}
