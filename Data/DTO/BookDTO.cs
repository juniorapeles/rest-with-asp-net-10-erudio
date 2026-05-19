using RestWithASPNET10Erudio.Model.Base;

namespace RestWithASPNET10Erudio.data
{
    public class BookDTO : BaseEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
