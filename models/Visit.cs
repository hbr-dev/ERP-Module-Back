namespace BackEnd.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime? Visit_date { get; set;}
        public int? Store_id { get; set; }

        public int? Status { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}