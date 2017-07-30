using System.ComponentModel.DataAnnotations;

namespace EmployeeApplication.Models
{
    public class EmployeeViewModel
    {
        public long EmployeeId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }
    }
}
