using System.ComponentModel.DataAnnotations;

namespace GameStore.Frontend.Models;

public class GameDetails
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    public int? GenreId { get; set; }

    [Required]
    [Range(1.00, 100.00)]
    public decimal Price { get; set; }
    public DateOnly? ReleaseDate { get; set; }
}
