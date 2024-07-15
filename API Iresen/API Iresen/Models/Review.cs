namespace API_Iresen.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int ReviewerId { get; set; }
        public User Reviewer { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Comments { get; set; }
        public int Score { get; set; }
    }
}
