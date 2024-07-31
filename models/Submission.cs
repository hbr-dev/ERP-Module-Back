namespace BackEnd.Models
{
    public class SubMission
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
        public int Mission_id { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}