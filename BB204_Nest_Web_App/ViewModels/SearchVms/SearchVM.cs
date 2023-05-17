using BB204_Nest_Web_App.Models;

namespace BB204_Nest_Web_App.ViewModels.SearchVms;

public class SearchVM
{
    public List<Category> Categories { get; set; }
    public string ProductName { get; set; }
    public int? CategoryId { get; set; }
}
