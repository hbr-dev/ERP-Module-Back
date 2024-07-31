namespace BackEnd.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Areamanager_id { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}