using System.ComponentModel.DataAnnotations;

namespace OAA.Web.Models
{
    public class AuthorViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
