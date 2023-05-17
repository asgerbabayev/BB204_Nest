using BB204_Nest_Web_App.Models;

namespace BB204_Nest_Web_App.ViewModels;

public class CommentVM
{
    public string Description { get; set; }
    public DateTime? Date { get; set; }
    public string ApplicationUserId { get; set; }
    public int ProductId { get; set; }
    public List<Comment> Comments { get; set; }
    public Product? Product { get; set; }
}
