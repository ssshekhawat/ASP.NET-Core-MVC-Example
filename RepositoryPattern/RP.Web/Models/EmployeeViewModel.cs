using System.ComponentModel.DataAnnotations;

namespace RP.Web.Models
{
    public class EmployeeViewModel
    {
        public long Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public decimal Salary { get; set; }
    }
}