namespace API_Iresen.Models
{
    public class ReviewForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ReviewCriteria> Criteria { get; set; }
    }

}
