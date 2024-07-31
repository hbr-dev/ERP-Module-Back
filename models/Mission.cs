namespace BackEnd.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descriprtion { get; set; }
        public int? Status { get; set; }
        public DateTime? Start_date { get; set; }
        public DateTime? End_date { get; set; }
        public int? Subject_id { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}