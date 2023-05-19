using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Festival_Finder.ViewModel
{
    public class RegisterViewModel
    {
        
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
