namespace BackEnd.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string? Question { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}