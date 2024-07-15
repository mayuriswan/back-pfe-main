namespace API_Iresen.Models
{
    public class ReviewCriteria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxScore { get; set; }
        public int ReviewId { get; set; }

        public Review? Review { get; set; }
    }
}
