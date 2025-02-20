using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6KW.Models
{
    public class Movie
    {
        // Primary Key for the Movie table
        [Key] [Required] public int MovieId { get; set; }

        // Foreign Key linking to the Category table
        [ForeignKey("CategoryId")] public int? CategoryId { get; set; }

        // Navigation property for the associated Category (nullable)
        public Category? Category { get; set; }

        // Title of the movie (Required field with validation)
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        // Year the movie was released (Required & must be 1888 or later)
        [Required]
        [Range(1888, 9999, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        // Director of the movie (Optional, defaults to an empty string)
        public string? Director { get; set; } = string.Empty;

        // Rating of the movie (e.g., PG, R, etc.) - Optional field
        public string? Rating { get; set; } = string.Empty;

        // Indicates if the movie has been edited (Required field)
        [Required(ErrorMessage = "Edited is required.")]
        public bool Edited { get; set; }

        // Name of the person the movie is lent to (Optional field)
        public string? LentTo { get; set; } = string.Empty;

        // Indicates if the movie is copied to Plex (Required field)
        [Required(ErrorMessage = "CopiedToPlex is required.")]
        public bool CopiedToPlex { get; set; }

        // Additional notes about the movie (Optional field)
        public string? Notes { get; set; } = string.Empty;
    }
}

