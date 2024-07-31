namespace BackEnd.Models
{
    public class Affectation
    {
        public int Id { get; set; }
        public int Mission_id { get; set;}
        public int Store_id { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}