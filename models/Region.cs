namespace BackEnd.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}