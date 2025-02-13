using System.ComponentModel.DataAnnotations;

namespace Mission6KW.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; } = false; // Change from bool? to bool
        
        public string? LentTo { get; set; } // Optional

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; } // Optional
    }
}