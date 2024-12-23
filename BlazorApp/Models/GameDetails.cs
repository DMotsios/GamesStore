using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models;

public class GameDetails
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name is too long")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Genre is required")]
    public string? GenreId { get; set; }

    [Range(1, 100, ErrorMessage = "Price must be between 1 and 100")]
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}