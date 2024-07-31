namespace BackEnd.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Belongs_to { get; set; }
        public int Group_id { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}