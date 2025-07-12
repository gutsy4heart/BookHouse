using System.ComponentModel.DataAnnotations;

namespace BookHouse.Model;

public class Book
{
    [Key]
    public int Id { get; set; }
    [Required]
    [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only letters.")]
    public string Title { get; set; }
    [Required]

    public string Description { get; set; }
    [Required]

    public string Author { get; set; } = string.Empty;
    [Required]
    public string Genre { get; set; } = string.Empty;
    [Required]
    public string Publishing { get; set; } = string.Empty;
    [Required]
    public string Created { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; }
}
