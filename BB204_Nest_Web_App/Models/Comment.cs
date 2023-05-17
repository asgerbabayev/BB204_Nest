namespace BB204_Nest_Web_App.Models;

public class Comment
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime? Date { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
    public string ApplicationUserId { get; set; }
    public Product? Product { get; set; }
    public int ProductId { get; set; }

}
