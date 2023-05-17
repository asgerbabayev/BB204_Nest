namespace BB204_Nest_Web_App.ViewModels;

public class PaginateVM<T>
{
    public List<T> Items { get; set; }
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
}
