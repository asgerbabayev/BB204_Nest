using System.ComponentModel.DataAnnotations;

namespace BB204_Nest_Web_App.ViewModels.AccountVms;

public class LoginVM
{
    public string UserNameOrEmail { get; set; } = null!;

    [MaxLength(255), DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    public bool RememberMe { get; set; }
}
