namespace BackEnd.Models
{
    public class QSTSubMission
    {
        public int Id { get; set; }
        public int Submission_id { get; set; }
        public int Question_id { get; set; }
        public int Answer { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}