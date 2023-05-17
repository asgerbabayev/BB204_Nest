namespace BB204_Nest_Web_App.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}
