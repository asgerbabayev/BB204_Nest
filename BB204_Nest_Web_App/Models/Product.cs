using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BB204_Nest_Web_App.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal SellPrice { get; set; }
    [Range(0, 5)]
    public decimal? Rating { get; set; }
    public decimal CostPrice { get; set; }
    public decimal? Discount { get; set; }
    public int StockCount { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public bool IsDeleted { get; set; }
    public List<ProductImage>? ProductImages { get; set; }
    [NotMapped]
    public IFormFile? PhotoBack { get; set; }
    [NotMapped]
    public IFormFile? PhotoFront { get; set; }
    [NotMapped]
    public List<IFormFile>? Files { get; set; }
    public ICollection<Tag>? Tags { get; set; }
    public ICollection<Comment>? Comments { get; set; }

}
