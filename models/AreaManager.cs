namespace BackEnd.Models
{
    public class AreaManager
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}