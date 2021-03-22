using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// gets error messages
using System.ComponentModel.DataAnnotations;
namespace HiltonBrotherMovieDB.Models
{
  
    public class MovieEntry
    {
        [Key]
        public int MovieEntryID { get; set; }
        [Required(ErrorMessage = "Category is a required field")]
        public String Category { get; set; }

        [Required(ErrorMessage = "Title is a required field")]
        [TitleValidate]
        
        public String Title { get; set; }

        [Required(ErrorMessage = "Year is a required field")]
        public String Year { get; set; }

        [Required(ErrorMessage = "Director is a required field")]
        public String Director { get; set; }

        [Required(ErrorMessage = "Rating is a required field")]
        public String Rating { get; set; }

        public Boolean Edited { get; set; }

        public String LentTo { get; set; }

        [MaxLength(25, ErrorMessage = "Notes must be less than 25 characters")]
        public String Notes { get; set; }


        // custome validation
        public class TitleValidate : ValidationAttribute
        {
            // who knows
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)

            {
                // comp[ares value passed in to independance day
                string Message = string.Empty;
                if (value.ToString().ToLower().Replace(" ", String.Empty) == "independanceday")
                {
                    Message = "We dont accept Independance Day because its not as patriotic as Rocky IV.";
                    return new ValidationResult(Message);
                }
                else
                {
                    return ValidationResult.Success;
                }
        }
        }

        public MovieEntry()
        {
        }

    }
}
