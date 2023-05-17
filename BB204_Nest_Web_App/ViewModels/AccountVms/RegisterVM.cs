using System.ComponentModel.DataAnnotations;

namespace BB204_Nest_Web_App.ViewModels.AccountVms;

public class RegisterVM
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string UserName { get; set; } = null!;
    [MaxLength(255), DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    [MaxLength(255), DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [MaxLength(255), DataType(DataType.Password), Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;
}