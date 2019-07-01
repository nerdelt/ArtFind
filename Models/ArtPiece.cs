﻿using System;
using System.ComponentModel.DataAnnotations;

namespace artfind.Models
{
    public class ArtPiece
    {
       public int ArtPieceID { get; set; }

       public string Title { get; set; }

       public int ArtistID { get; set; }

       public Artist Artist { get; set; }
      
       [Display(Name = "Year Created")]
       public int YearCreated { get; set; }

       public string Dimensions { get; set; }

       public string Medium { get; set; }

       [Display(Name = "Country Created")]
       public string CountryCreated { get; set; }



       //public Current Location
       //photo of work

    }
}
