using System.Collections.Generic;

namespace GRP.Data
{
    public class Customer: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
