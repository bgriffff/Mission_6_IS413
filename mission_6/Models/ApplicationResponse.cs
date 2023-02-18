using System;
using System.ComponentModel.DataAnnotations;

namespace mission_6.Models
{
    public class ApplicationResponse
    {

        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Make sure to include a title for this movie.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This must be a number between 1910 and the Current Year.")]
        [Range(1910, 2030)]
        public ushort Year { get; set; }

        [Required(ErrorMessage = "Make sure to include a director for this movie.")]
        [MaxLength(25)]
        public string Director { get; set; }

        [Required(ErrorMessage = "Add a rating.")]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        [MaxLength(25)]
        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

        //Foreign Key
        public int CategoryId { get; set; }

        //This creates the relationship from this table to the Category table
        public Category Category { get; set; }
    }
}