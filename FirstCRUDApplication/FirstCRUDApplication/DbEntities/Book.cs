namespace FirstCRUDApplication.DbEntities
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
    }
}
