using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Net.Application.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The Name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name of product")]
    public string Name { get; set; } = string.Empty;
    
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Description of product")]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "The Price is required")]
    [Range(1, 9999.99)]
    [DisplayName("Price of product")]
    public decimal Price { get; set; }
}