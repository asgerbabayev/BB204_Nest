using Microsoft.AspNetCore.Identity;

namespace BB204_Nest_Web_App.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
