using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BB204_Nest_Web_App.ViewModels.CategoryVMs;

public class CategoryVM
{
    public int Id { get; set; }
    [MaxLength(100), MinLength(2)]
    public string Name { get; set; } = null!;
    public string Logo { get; set; } = null!;
    public string? Photo { get; set; }
    [NotMapped]
    public IFormFile? PhotoFile { get; set; }
}
