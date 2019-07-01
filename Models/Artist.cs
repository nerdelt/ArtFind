using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace artfind.Models
{
    public enum Gender
    {
        Female,
        Male,
        Other
    }

    public class Artist

    {
        
        public int ID { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        public string Nationality { get; set; }

        public Gender? Gender { get; set; }
        //public ICollection<Art> Art { get; set; }

    }
}


