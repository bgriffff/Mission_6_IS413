using System.ComponentModel.DataAnnotations;

namespace mission_6.Models
{
    public class ApplicationResponse
    {
        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public ushort Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}