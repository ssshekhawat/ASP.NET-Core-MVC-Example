namespace GRP.Data
{
    public class Address : BaseEntity
    {
        public long CustomerId { get; set; }
        public string AddressLine1 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
