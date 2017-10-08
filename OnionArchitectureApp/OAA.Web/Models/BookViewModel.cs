using System.ComponentModel.DataAnnotations;

namespace OAA.Web.Models
{
    public class BookViewModel
    {
        [Display(Name ="Book Name")]
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
    }
}
