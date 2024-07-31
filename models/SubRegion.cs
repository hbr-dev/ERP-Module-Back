namespace BackEnd.Models
{
    public class SubRegion
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Region_id { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}